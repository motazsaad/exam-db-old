using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exam_db.Models
{


    public enum FileType
    {
        png,
        Jpg,
        Pdf
    }
    public class File
    { 
        public int Id { get; set; }
        public String title { get; set; }
        public String path { get; set; }
        public FileType type{ get; set; }
        public long size { get; set; }
        public int like_number { get; set; }
        public int dislike_number { get; set; }
        public int Download_number { get; set; }
        public int view_numbre { get; set; }
        
    }
}