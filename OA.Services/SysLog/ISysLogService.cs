using CommonLib.Libs;
using OA.Entitys;
using OA.Entitys.OaAuthDB;
using OA.Entitys.OaSyslogDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Services.SysLog
{
    public interface ISysLogService
    {
        /// <summary>
        /// 记录登录动作
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        bool LoginSuccessLog(string ip,string account);
        /// <summary>
        /// 记录登录动作
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        bool LoginFaildLog(string ip,string account);
        /// <summary>
        /// 记录登出动作
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        bool LogoutLog(string ip,string account);
    }
    public class SysLogService : ISysLogService
    {
        private readonly oa_authContext _authDB;
        private readonly oa_syslogContext _logDB;

        public SysLogService(oa_authContext authDB, oa_syslogContext logDB)
        {
            _authDB = authDB;
            _logDB = logDB;
        }
        private bool AddMsg(string ip,string app,string user,string type,string content, BaseDataType.SysLogSeverityLevel level)
        {
            try
            {
                _logDB.Syslog.Add(new Syslog
                {
                    LogTimestamp = TimeHelper.GetTimeStamp(),
                    HostName = ip,
                    AppName = app,
                    Level = (sbyte)level,
                    MsgContent = content,
                    MsgUser = user,
                    MsgType = type
                });
                _logDB.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool LoginFaildLog(string ip, string account)
        {
            return AddMsg(ip, "Login", account, "认证事件", "手动登录系统密码验证失败", BaseDataType.SysLogSeverityLevel.LOG_ERR);
        }
        public bool LoginSuccessLog(string ip, string account)
        {
            return AddMsg(ip, "Login", account, "认证事件", "手动登录系统成功", BaseDataType.SysLogSeverityLevel.LOG_INFO);
        }

        public bool LogoutLog(string ip, string account)
        {
            return AddMsg(ip, "Logout", account, "认证事件", "手动注销登录", BaseDataType.SysLogSeverityLevel.LOG_INFO);
        }
    }
}
