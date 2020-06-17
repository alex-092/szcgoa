using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Entitys
{
    public static class BaseDataType
    {
        public enum UserAcountLockType
        {
            NORMAL,  //正常账户
            TOO_MANY_LOGIN, //过多登录锁定
            ADMIN_LOCK,  //管理员操作锁定
            NOT_APPROVE,   //未认证用户
            ERROR = 10  //error
        }
        
        public enum UserTaskListType
        {
            UNNAMED,  //未定
            WAIT_FOR_APPROVE,  //等待认证账户,该事件发送给所有level小于3的角色
        }
        public enum SysLogSeverityLevel
        {
            LOG_EMERG = 0,   //Emergency: system is unusable
            LOG_ALERT,      //Alert: action must be taken immediately
            LOG_CRIT,       //Critical: critical conditions
            LOG_ERR,        //Error: error conditions
            LOG_WARNING,    //Warning: warning conditions
            LOG_NOTICE,     //Notice: normal but significant condition
            LOG_INFO,       //Informational: informational messages
            LOG_DEBUG       //Debug: debug-level messages
        }
        public enum MessageSenderStatus
        {
            NORMAL,  //正常发送的普通信息
            NEED_CONFIRM, //需要接收者确认的信息
        }
        public enum MessageReaderStatus
        {
            NORMAL,  //正常接受的普通信息
            BE_TOP,  //用户设定置顶接受的信息
        }
        public enum MessageContentType
        {
            USER_MESSAGE,  //普通用户邮件信息
            SYSTEM_MESSAGE,  //系统提示信息
            USER_ANNOUNCE,   //权限用户发布的公告
            SYSTEM_ANNOUNCE,  //系统发布的公告
            USER_ARTICLE,    //用户发布的文章
            COMMENT,        //对指定信息的评论
        }
        public enum MessageContentSubType
        {
            NORMAL,  //信息标准状态
            DRAFT,  //草稿状态
        }

    }
    public static class SysStringTemplate
    {
        public static string MakeSysMessage(string sender)
        {
            return @""+sender;
        }
    }
    public static class BaseStringType
    {
        public const string UserClaimType_ApproveUid = "ApproveID";
    }
    public static class ConfigStrings
    {
        public const string SZCGOA_AuthenticationScheme = "SZCGOACookies";
    }
}
