using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagement.Repository;
using StudentManagement.Business;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private StudentManager _studentManager = null;
        public StudentController()
        {
            _studentManager = new StudentManager();
        }

        //
        // GET: /Student/
        public ActionResult Index()
        {
            List<Student> students = _studentManager.GetStudents().ToList();
            return View(students);
        }

        public ActionResult Create()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            _studentManager.Add(student);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var students = _studentManager.GetStudents();
            Student student = students.Where(p => p.Id == id).FirstOrDefault();
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            _studentManager.Edit(student);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _studentManager.Delete(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var students = _studentManager.GetStudents();
            Student student = students.Where(p => p.Id == id).FirstOrDefault();
            return View(student);
        }
    }
}