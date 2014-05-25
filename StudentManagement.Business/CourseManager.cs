using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Repository;

namespace StudentManagement.Business
{
    
    public class CourseManager
    {
        private SchoolManagementEntities _dbEntities = null;

        public CourseManager()
        {
            _dbEntities = new SchoolManagementEntities();
        }

        public void Add(Course course)
        {
            _dbEntities.Courses.Add(course);
            _dbEntities.SaveChanges();
        }

        public void Delete(int id)
        {
            Course course = _dbEntities.Courses.Where(p => p.Id == id).FirstOrDefault();
            if (course != null) {
                _dbEntities.Courses.Remove(course);
                _dbEntities.SaveChanges();
            }

        }

        public void Edit(Course course)
        {
            Course courseToUpdate = _dbEntities.Courses.Where(p => p.Id == course.Id).FirstOrDefault();
            if (courseToUpdate != null) {
                courseToUpdate.Name = course.Name;
                courseToUpdate.Code = course.Code;
                courseToUpdate.Credit = course.Credit;
                _dbEntities.SaveChanges();
            }
        }

        public IEnumerable<Course> GetCourses()
        {
            return _dbEntities.Courses.ToList();
        }
    }
}
