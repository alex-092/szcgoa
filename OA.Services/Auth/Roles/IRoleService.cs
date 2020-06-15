using OA.Entitys.OaAuthDB;
using OA.Entitys.OaCoreDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA.Services.Auth.Roles
{
    public interface IRoleService
    {
        /// <summary>
        /// 所有角色列表
        /// </summary>
        /// <returns></returns>
        List<AuthRoles> GetAllRoles();
        bool AddRole(string title,string descript,sbyte level);
        bool EditRole(string title,string descript,sbyte level,int id);
        bool DeleteRole(int id);
        /// <summary>
        /// 根据role的id查找所有属于该role的用户李彪
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        List<AuthUsers> GetUserListByRoleID(int roleid);
        /// <summary>
        /// 根据传入的role列表查找所有所属的用户列表去重
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        List<AuthUsers> GetUsersByRoleList(List<AuthRoles> roles);
        /// <summary>
        /// 根据用户id查找该用户拥有的所有角色
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        List<AuthRoles> GetUserRolesByUserID(string uid);
        /// <summary>
        /// 根据level级别查找高于level的角色列表,用户只能批准大于自身level的角色
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        List<AuthRoles> GetRoleListByLevel(int level);
        /// <summary>
        /// 增加或删除用户所属角色
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        bool UserEditRole(string userID,int roleID);
        /// <summary>
        /// 根据roleid获取访问权限字符串
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        string GetRoleAccess(int roleid);
        /// <summary>
        /// 根据角色id给角色设定访问权限字符串
        /// </summary>
        /// <param name="roleid"></param>
        /// <param name="accessString"></param>
        /// <returns></returns>
        bool SetRoleAccess(int roleid, string accessString);

    }

    public class RoleService : IRoleService
    {
        private readonly oa_authContext _authDB;
        private readonly oa_coreContext _coredb;

        public RoleService(oa_authContext authDB, oa_coreContext coredb)
        {
            _authDB = authDB;
            _coredb = coredb;
        }

        public bool AddRole(string title, string descript, sbyte level)
        {
            _authDB.AuthRoles.Add(new AuthRoles { 
                Rolename=title,Roledescript=descript,Level=level
            });
            _authDB.SaveChanges();
            return true;
        }

        public bool DeleteRole(int id)
        {
            var target = _authDB.AuthRoles.Where(o => o.Id == id).FirstOrDefault();
            if (target != null)
            {
                _authDB.AuthRoles.Remove(target);
                _authDB.SaveChanges();
                return true;
            }
            return false;
            
        }

        public bool EditRole(string title, string descript, sbyte level, int id)
        {
            var target = _authDB.AuthRoles.Where(o => o.Id == id).FirstOrDefault();
            if (target != null)
            {
                target.Rolename = title;
                target.Roledescript = descript;
                target.Level = level;
                _authDB.AuthRoles.Update(target);
                _authDB.SaveChanges();
                return true;
            }
            return false;
            
        }

        public List<AuthRoles> GetAllRoles()
        {
            return _authDB.AuthRoles.ToList();
        }

        public string GetRoleAccess(int roleid)
        {
            var result =_coredb.AuthRoleAccess.Where(o => o.RoleId == roleid).FirstOrDefault();
            if (result == null)
                return null;
            return result.MenuIdString;
        }

        public List<AuthRoles> GetRoleListByLevel(int level)
        {
            return _authDB.AuthRoles.Where(o => o.Level <= level).ToList();
        }

        public List<AuthUsers> GetUserListByRoleID(int roleid)
        {
            var flag = _authDB.AuthUserRoles.Where(o => o.RoleId == roleid).ToList();
            var result = new List<AuthUsers>();
            foreach (var item in flag)
            {
                result.Add(_authDB.AuthUsers.FirstOrDefault(o => o.Uid == item.UserId));
            }
            return result;
        }

        public List<AuthRoles> GetUserRolesByUserID(string uid)
        {
            var flag = _authDB.AuthUserRoles.Where(o => o.UserId == uid).ToList();
            var result = new List<AuthRoles>();
            foreach (var item in flag)
            {
                result.Add(_authDB.AuthRoles.FirstOrDefault(o => o.Id == item.RoleId));
            }
            return result;
        }

        public List<AuthUsers> GetUsersByRoleList(List<AuthRoles> roles)
        {
            var result = new List<AuthUsers>();
            foreach (var item in roles)
            {
                result.AddRange(GetUserListByRoleID(item.Id));
            }
            return result.Where((x, i) => result.FindIndex(z => z.Uid == x.Uid) == i).ToList(); 
        }

        public bool SetRoleAccess(int roleid, string accessString)
        {
            if (roleid == 0 || string.IsNullOrEmpty(accessString))
                return false;
            var target = _coredb.AuthRoleAccess.Where(o => o.RoleId == roleid).FirstOrDefault();
            if (target == null)
                _coredb.AuthRoleAccess.Add(new AuthRoleAccess { RoleId = roleid, MenuIdString = accessString });
            else
            {
                target.MenuIdString = accessString;
                _coredb.AuthRoleAccess.Update(target);
            }
            _coredb.SaveChanges();
            return true;
        }

        public bool UserEditRole(string userID, int roleID)
        {
            try
            {
                var flag = _authDB.AuthUserRoles.Where(o => o.RoleId == roleID && o.UserId == userID).FirstOrDefault();
                if (flag == null)
                {
                    _authDB.AuthUserRoles.Add(new AuthUserRoles { UserId = userID, RoleId = roleID });
                }
                else
                {
                    _authDB.AuthUserRoles.Remove(flag);
                }
                _authDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }          
        }
    }
}
