using System;
using System.Collections.Generic;
using System.Text;
using CommonLib.Libs;
using OA.Entitys;
using OA.Entitys.OaMsgDB;
using OA.Entitys.OaMsgModels;

namespace OA.Services.Core.Message
{
    public interface IOAMsgService
    {
        bool CreateUserMessage(string uid, string targetId, string title, string content, int needconfirm, string brief = null);
        List<InBoxListModel> GetInBoxList(string uid);
        List<SendBoxListModel> GetSendBoxList(string uid);
        MsgContent GetMessageContent(int msgid);
        int GetUnReadMsgCount(string uid);
    }
    public class OAMsgService : IOAMsgService
    {
        private readonly oa_msgContext _msgDB;

        public OAMsgService(oa_msgContext msgDB)
        {
            _msgDB = msgDB;
        }
        private int AddContent(string title,string brief,string content,int type,int subtpe,int targetid,string createby)
        {
            try
            {
                var newcontent = new MsgContent
                {
                    Title = title,
                    Brief = brief,
                    Content = content,
                    Type = type,
                    Subtype = subtpe,
                    CreateBy = createby,
                    TargetId = targetid,
                    CreateTime = TimeHelper.GetTimeStamp()
                };
                _msgDB.MsgContent.Add(newcontent);
                _msgDB.SaveChanges();
                return _msgDB.Entry(newcontent).Entity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool AddReaderItem(string uid,string senderuid,int msgid,int status)
        {
            try
            {
                _msgDB.MsgReader.Add(new MsgReader
                {
                    Uid=uid,
                    SenderId=senderuid,
                    MsgId=msgid,
                    Status=status,
                    CreateTime = TimeHelper.GetTimeStamp()
                });
                _msgDB.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool AddSenderItem(string uid,string reciveruid,int msgid,int status)
        {
            try
            {
                _msgDB.MsgSender.Add(new MsgSender
                {
                    Uid=uid,
                    ReaderId=reciveruid,
                    MsgId=msgid,
                    Status=status,
                    CreateTime = TimeHelper.GetTimeStamp()
                });
                _msgDB.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CreateUserMessage(string uid, string targetId, string title, string content, int needconfirm, string brief = null)
        {
            var msgId = AddContent(title, brief, content, (int)BaseDataType.MessageContentType.USER_MESSAGE,
                (int)BaseDataType.MessageContentSubType.NORMAL, 0, uid);
            AddReaderItem(targetId, uid, msgId, 0);
            AddSenderItem(uid, targetId, msgId, needconfirm);
            return true;
        }

        public List<InBoxListModel> GetInBoxList(string uid)
        {
            throw new NotImplementedException();
        }

        public MsgContent GetMessageContent(int msgid)
        {
            throw new NotImplementedException();
        }

        public List<SendBoxListModel> GetSendBoxList(string uid)
        {
            throw new NotImplementedException();
        }

        public int GetUnReadMsgCount(string uid)
        {
            throw new NotImplementedException();
        }
    }
}
