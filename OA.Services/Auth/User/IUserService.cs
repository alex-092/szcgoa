using CommonLib.Libs;
using Microsoft.Extensions.Caching.Memory;
using OA.Entitys;
using OA.Entitys.OaAuthDB;
using OA.Entitys.OaCoreDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OA.Services.Auth.User
{
    public interface IUserService
    {
        /// <summary>
        /// 检查账户是否被锁定
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        BaseDataType.UserAcountLockType CheckAccountLock(string account);
        /// <summary>
        /// 根据id查找用户
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        AuthUsers FindByID(string uid);
        /// <summary>
        /// 根据phone查找用户
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        AuthUsers FindByPhone(string phone);
        /// <summary>
        /// 根据account名查找用户
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        AuthUsers FindByUsername(string username);
        /// <summary>
        /// 获取所用用户列表并cache存储
        /// </summary>
        /// <returns></returns>
        List<AuthUsers> GetUserList();
        /// <summary>
        /// 判断账户是否被删除
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        bool IsDeleted(string account);
        /// <summary>
        /// 判断账户与密码是否匹配
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool ValidateAccount(string account, string password);
        /// <summary>
        /// 数据库中保存登录记录
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool AddLoginClue(AuthUsers user, string ip, string client);
        /// <summary>
        /// 注册基本账户
        /// </summary>
        /// <param name="displayname"></param>
        /// <param name="account"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool RegisterAccount(string displayname, string account, string phone, string email, string password);
        /// <summary>
        /// 执行未认证用户授权认证
        /// </summary>
        /// <param name="aproverID"></param>
        /// <param name="targetID"></param>
        /// <returns></returns>
        bool ApproveUser(string aproverID, string targetID);
        /// <summary>
        /// 用户账户软删除
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        bool DeleteUser(string uid);

        /// <summary>
        /// 忘记密码后.根据用户名,电话与Email确认用户所有者
        /// </summary>
        /// <param name="account"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        AuthUsers UserClaimAccount(string account, string phone, string email);
        /// <summary>
        /// 直接修改密码
        /// </summary>
        /// <param name="newPass"></param>
        /// <returns></returns>
        bool UserChangePassword(AuthUsers user,string newPass);
        /// <summary>
        /// 确认原密码后修改密码
        /// </summary>
        /// <param name="newPass"></param>
        /// <param name="oldPass"></param>
        /// <returns></returns>
        bool UserChangePassword(AuthUsers user, string newPass,string oldPass);

    }
    public class UserService : IUserService
    {
        private readonly oa_authContext _db;
        private readonly oa_coreContext _coredb;
        private readonly IMemoryCache _cache;

        public UserService(oa_authContext db, IMemoryCache cache, oa_coreContext coredb)
        {
            _db = db;
            _cache = cache;
            _coredb = coredb;
        }
        public List<AuthUsers> GetUserList()
        {
            var result = new List<AuthUsers>();
            if (!_cache.TryGetValue("AllSystemUsers", out result))
            {
                result = _db.AuthUsers.ToList();
                _cache.Set("AllSystemUsers", result, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5)));
            }
            return result;
        }
        public AuthUsers FindByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("message", nameof(username));
            }

            return _db.AuthUsers.FirstOrDefault(o => o.Account == username);
        }
        public AuthUsers FindByPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("message", nameof(phone));
            }

            return _db.AuthUsers.FirstOrDefault(o => o.Phone == phone);
        }
        public AuthUsers FindByID(string uid)
        {
            if (string.IsNullOrEmpty(uid))
            {
                throw new ArgumentException("message", nameof(uid));
            }

            return _db.AuthUsers.FirstOrDefault(o => o.Uid == uid);
        }
        public bool ValidateAccount(string account, string password)
        {
            return FindByUsername(account)?.Password.Equals(EncryptorHelper.GetSZCGPassword(password)) ?? false;
        }

        public BaseDataType.UserAcountLockType CheckAccountLock(string account)
        {
            AuthUsers user = _db.AuthUsers.FirstOrDefault(o => o.Account == account);
            if (user == null)
                return BaseDataType.UserAcountLockType.ERROR;
            return (BaseDataType.UserAcountLockType)user.LockType;
        }
        public bool IsDeleted(string account)
        {
            AuthUsers user = _db.AuthUsers.FirstOrDefault(o => o.Account == account);
            if (user == null || user.IsDelete != 0)
                return true;
            return false;
        }

        public bool RegisterAccount(string displayname, string account, string phone, string email, string password)
        {
            var guid = Guid.NewGuid().ToString();
            _db.AuthUsers.Add(new AuthUsers()
            {
                Uid = guid,
                DisplayName = displayname,
                Account = account,
                Phone = phone,
                Email = email,
                PhoneConfirmed = 0,
                Password = EncryptorHelper.GetSZCGPassword(password),
                UserType = 0,
                LockType = 3,
                LockStamp = TimeHelper.GetTimeStamp(),
                CreateTime = TimeHelper.GetTimeStamp(),
                IsDelete = 0
            });
            _coredb.SysTasklist.Add(new SysTasklist
            {
                HandleName = "Approve Task",
                TargetUid = guid,
                TargetName = displayname,
                TaskType = (int)BaseDataType.UserTaskListType.WAIT_FOR_APPROVE,
                Isdone = 0,
                CreateTime = TimeHelper.GetTimeStamp()
            });
            _coredb.SaveChanges();
            _db.SaveChanges();
            return true;
        }


        public AuthUsers UserClaimAccount(string account, string phone, string email)
        {
            return _db.AuthUsers.FirstOrDefault(o=>o.Account == account && o.Phone == phone && o.Email == email);
        }

        public bool UserChangePassword(AuthUsers user, string newPass)
        {
            if (string.IsNullOrEmpty(newPass))
                return false;
            user.Password = EncryptorHelper.GetSZCGPassword(newPass);
            _db.AuthUsers.Update(user);
            _db.SaveChanges();
            return true;
        }

        public bool UserChangePassword(AuthUsers user, string newPass, string oldPass)
        {
            if (user.Password.Equals(EncryptorHelper.GetSZCGPassword(oldPass)))
            {
                if (string.IsNullOrEmpty(newPass))
                    return false;
                user.Password = EncryptorHelper.GetSZCGPassword(newPass);
                _db.AuthUsers.Update(user);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ApproveUser(string aproverID, string targetID)
        {
            var targetUser = _db.AuthUsers.FirstOrDefault(o => o.Uid == targetID);
            if (targetID == null)
                return false;
            targetUser.LockType = (int)BaseDataType.UserAcountLockType.NORMAL;
            _db.AuthUsers.Update(targetUser);
            _db.AuthUserClaims.Add(new AuthUserClaims { Type=BaseStringType.UserClaimType_ApproveUid,Value=aproverID,UserId=targetID});
            _db.SaveChanges();
            return true;
        }

        public bool DeleteUser(string uid)
        {
            var targetUser = _db.AuthUsers.FirstOrDefault(o => o.Uid == uid);
            if (uid == null)
                return false;
            targetUser.IsDelete = 1;
            _db.AuthUsers.Update(targetUser);
            _db.SaveChanges();
            return true;
        }

        public bool AddLoginClue(AuthUsers user,string ip,string client)
        {
            if (user != null)
            {
                _db.AuthUserlogins.Add(new AuthUserlogins
                {
                    Uid = user.Uid,
                    LoginIp = ip,
                    LoginClient = client,
                    LoginTimestamp = TimeHelper.GetTimeStamp()
                }) ;
                _db.SaveChanges();
                return true;
            }
            return false;           
        }
    }
}
