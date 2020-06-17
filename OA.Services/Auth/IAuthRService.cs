using OA.Entitys.OaAuthDB;
using OA.Entitys.OaCoreDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA.Services.Auth
{
    public interface IAuthRService
    {
        /// <summary>
        /// 判断用户是否有访问path的权限
        /// </summary>
        /// <param name="path"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        bool CheckPath(string path,string uid);
    }
    public class AuthRService: IAuthRService
    {
        private readonly oa_authContext _authDB;
        private readonly oa_coreContext _coredb;
        public AuthRService(oa_authContext authDB, oa_coreContext coredb)
        {
            _authDB = authDB;
            _coredb = coredb;
        }
        public bool CheckPath(string path, string uid)
        {
            throw new NotImplementedException();
        }
        private List<AuthRoles> GetUserRolesByUserID(string uid)
        {
            var flag = _authDB.AuthUserRoles.Where(o => o.UserId == uid).ToList();
            var result = new List<AuthRoles>();
            foreach (var item in flag)
            {
                result.Add(_authDB.AuthRoles.FirstOrDefault(o => o.Id == item.RoleId));
            }
            return result;
        }

        
    }
     
}
