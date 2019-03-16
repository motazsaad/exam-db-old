using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exam_db.Models
{
    public class College
    {
        public int Id { get; set; }
        public String name { get; set; }
        public virtual ICollection<Department> listOfDepartment { get; set; }
    }
}