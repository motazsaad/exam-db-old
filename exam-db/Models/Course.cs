using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exam_db.Models
{
    public class Course
    {
        public int Id { get; set; }
        public String name { get; set; }
        public String code { get; set; }
        public virtual ICollection<File> listOfFile { get; set; }
        public int departmentId { get; set; }
        public virtual Department department { get; set; }
        
    }
}