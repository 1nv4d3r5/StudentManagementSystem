using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagement.Repository;
using StudentManagement.Business;

namespace StudentManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        private CourseManager _courseManager = null;
        public CourseController()
        {
            _courseManager = new CourseManager();
        }

        //
        // GET: /Student/
        public ActionResult Index()
        {
            List<Course> courses = _courseManager.GetCourses().ToList();
            return View(courses);
        }

        public ActionResult Create()
        {
            return View(new Course());
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            _courseManager.Add(course);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var courses = _courseManager.GetCourses();
            Course course = courses.Where(p => p.Id == id).FirstOrDefault();
            return View(course);
        }
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            _courseManager.Edit(course);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _courseManager.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var courses = _courseManager.GetCourses();
            Course student = courses.Where(p => p.Id == id).FirstOrDefault();
            return View(student);
        }
	}
}