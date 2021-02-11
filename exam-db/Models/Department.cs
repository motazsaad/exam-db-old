using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace exam_db.Models
{
    public class Department
    {
        public int Id { get; set; }
        public String name { get; set; }
        public virtual ICollection<Course> listOfCourse { get; set; }
        public int collegeId { get; set; }
        public virtual College college { get; set; }
       


    }
}