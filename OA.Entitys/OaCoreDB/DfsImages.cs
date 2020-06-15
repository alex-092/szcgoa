using System;
using System.Collections.Generic;

namespace OA.Entitys.OaCoreDB
{
    public partial class DfsImages
    {
        public uint Id { get; set; }
        public int? Type { get; set; }
        public string Folder { get; set; }
        public string ImgTitle { get; set; }
        public string UserId { get; set; }
        public string DfsPath { get; set; }
        public int? CreateTime { get; set; }
    }
}
