using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace exam_db.Models
{
    public class University
    {
        public int Id { get; set; }
        public String name { get; set; }
        public String country { get; set; }
        public String logo_path { get; set; }
        public virtual ICollection<College> listOfCollege { get; set; }

    }
}