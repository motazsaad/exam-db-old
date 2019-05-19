using exam_db.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace exam_db.Controllers
{
    public class WebController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult UniversityRequirements()
        {
            return View();
        }

        public ActionResult College(int CollegeId)
        {

            College college = db.Colleges.Find(CollegeId);
            ViewBag.CollegeName = college.name;
            ViewBag.CollegeId = college.Id;
            ViewBag.Departments = college.listOfDepartment.Skip(1);
            ViewBag.DepartmentsCount = college.listOfDepartment.Count;
            Department firstdept = college.listOfDepartment.First();
            ViewBag.listOfCourses = firstdept.listOfCourse;
            ViewBag.listOfIds = college.listOfDepartment;
            
                //foreach( Department dept in college.listOfDepartment)
            //{
            // if(depId == dept.Id)
            //    {
            //        ViewBag.listOfCourses = dept.listOfCourse;
            //    }   
            //}
            ViewBag.First = college.listOfDepartment.First();
            return View();
        }
  
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Getdept(int id)
        {
            List<Course> courses = new List<Course>();
            Department dep = db.Departments.Single(a => a.Id.Equals( id));
            //IQueryable<ICollection<Course>> listOfCourses = from q in db.Departments where q.Id == data.depid select q.listOfCourse;
            foreach (Course course in dep.listOfCourse)
            {
                courses.Add(course);
            }
            var list = JsonConvert.SerializeObject(courses,
                                    Formatting.None,
                                    new JsonSerializerSettings()
                                    {
                                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                                    });
                     //string responseText = JSON.Validate(courses);
            //return Json( list , "application/json") ;

            return Json(new {
                data = list
            }, JsonRequestBehavior.AllowGet);

        }
      
        public ActionResult Course(int courseId , String CollegeName)
        {
            Course course = db.Courses.Find(courseId);
            ViewBag.courseName = course.name;
            ViewBag.ListOfile = course.listOfFile;
            // code for test 
            List<File> quizez = new List<File>();
            List<File> others = new List<File>();
            List<File> exams = new List<File>();
            List<File> Summarieses = new List<File>();
            foreach(File file in course.listOfFile)
            {
                switch (file.Category)
                {
                    case "quiz":
                        quizez.Add(file);
                        break;
                    case "others":
                        others.Add(file);
                        break;
                    case "exam":
                        exams.Add(file);
                        break;
                    case "Summaries":
                        Summarieses.Add(file);
                        break;
                }

            }

            ViewBag.Quizez = quizez;
            ViewBag.others = others;
            ViewBag.exams = exams;
            ViewBag.Summarieses = Summarieses;
            ViewBag.CollegeName = CollegeName;
            Department department = db.Departments.Find(course.departmentId);
            ViewBag.departmentName = department.name;
            return View();
        }

        public ActionResult File()
        {
            return View();
        }
    }
}