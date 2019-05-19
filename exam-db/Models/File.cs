using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exam_db.Models
{


    public enum FileType
    {

        csv,
        txt,
        png,
        Jpg,
        Pdf,
        ppt,
        xls,
        docx,
        number,
        pages,
        key,
        rtf,
        oft,
        lba
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
        public int year { get; set; }
        public int semester { get; set; }
        public String Category { get; set; }//file category (quiz , exam,others,Summaries);
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

    }
}