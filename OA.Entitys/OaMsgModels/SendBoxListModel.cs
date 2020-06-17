using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Entitys.OaMsgModels
{
    public class SendBoxListModel
    {
        public int Id { get; set; }
        public string Uid { get; set; }
        public int? MsgId { get; set; }
        public string ReaderId { get; set; }
        public int? Status { get; set; }
        public int? CreateTime { get; set; }

        public string Title { get; set; }
        public int? Type { get; set; }
        public int? Subtype { get; set; }
    }
}
