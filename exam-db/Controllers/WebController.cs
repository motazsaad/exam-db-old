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
            ViewBag.First = college.listOfDepartment.First();
            return View();
        }
  
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Getdept(int id)
        {
            List<Course> courses = new List<Course>();
            List<Object> Mycourses = new List<Object>();
            Department dep = db.Departments.Single(a => a.Id.Equals(id));
            JsonArrayAttribute coursesArray = new JsonArrayAttribute();
            String myjson = "";
            
            //IQueryable<ICollection<Course>> listOfCourses = from q in db.Departments where q.Id == data.depid select q.listOfCourse;
            foreach (Course course in dep.listOfCourse)
            {
                //courses.Add(course);
                Course mycourse = new Course();
                mycourse.Id = course.Id;
                mycourse.name = course.name;
                mycourse.code = course.code;
                mycourse.listOfFile = course.listOfFile;
                mycourse.departmentId = course.departmentId;

                Object myObject = new {
                    course = new Course() { Id = course.Id, name = course.name, code = course.code ,departmentId = course.departmentId }
                };
                Mycourses.Add(myObject);

               
                    myjson = JsonConvert.SerializeObject(mycourse, Formatting.None);
              
                
                
               
            }


           
            //String jsonArray = JsonConvert.SerializeObject
            //JsonArrayAttribute
            var list = JsonConvert.SerializeObject(courses,
                                    Formatting.None,
                                    new JsonSerializerSettings()
                                    {
                                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                                    });
            //var list2 = JsonConvert.SerializeObject(Mycourses,
            //                        Formatting.None,
            //                        new JsonSerializerSettings()
            //                        {
            //                            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            //                        });
            var list2 = JsonConvert.SerializeObject(Mycourses , Formatting.Indented);
            //string responseText = JSON.Validate(courses);
            //return Json( list , "application/json") ;


            return Json(new {
                data = list2
            }, JsonRequestBehavior.AllowGet);

        }
      
        public ActionResult Course(int courseId , String CollegeName)
        {
            Course course = db.Courses.Find(courseId);
            ViewBag.CourseId = courseId;
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
                    case "Quizs":
                        quizez.Add(file);
                        break;
                    case "Others":
                        others.Add(file);
                        break;
                    case "Exams":
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
        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
        public ActionResult GetFiles(String filetype,int courseId)
        {
            Course course = db.Courses.Find(courseId);
            List<Object> MyFiles = new List<Object>();
            String myJson = "";

            foreach (File file in course.listOfFile)
            {

                if (file.Category.Equals(UppercaseFirst(filetype)))
                {
                    File myfile = new File();
                    myfile.Category = file.Category;
                    myfile.Course = file.Course;
                    myfile.CourseId = file.CourseId;
                    myfile.dislike_number = file.dislike_number;
                    myfile.Download_number = file.Download_number;
                    myfile.Id = file.Id;
                    myfile.like_number = file.like_number;
                    myfile.path = file.path;
                    myfile.semester = file.semester;
                    myfile.size = file.size;
                    myfile.title = file.title;
                    myfile.type = file.type;
                    myfile.view_numbre = file.view_numbre;
                    myfile.year = file.year;

                    Object myobject = new
                    {
                        file = new File()
                        {
                            Id = myfile.Id,
                            Category = myfile.Category,
                            dislike_number = myfile.dislike_number,
                            Download_number = myfile.Download_number,
                            like_number = myfile.like_number,
                            path = myfile.path,
                            semester = myfile.semester,
                            size = myfile.size,
                            title = myfile.title,
                            type = myfile.type,
                            view_numbre = myfile.view_numbre,
                            year = myfile.year
                        }
                    };
                    MyFiles.Add(myobject);

                }


                

            }
            var fileList = JsonConvert.SerializeObject(MyFiles, Formatting.Indented);
            return Json(new
            {
                data = fileList 
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult File()
        {
            return View();
        }

        public JsonResult getDepartment(String idString)
        {
            int i = 0;
            Int32.TryParse(idString, out i);

            db.Configuration.ProxyCreationEnabled = false;
            var deparments = db.Departments.Where(a => a.collegeId == i).ToList();

            ViewBag.test = "Hello";
            return Json(deparments, JsonRequestBehavior.AllowGet);
        }

    }
}