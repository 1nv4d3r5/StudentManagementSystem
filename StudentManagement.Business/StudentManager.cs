using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagement.Repository;

namespace StudentManagement.Business
{
    public class StudentManager
    {
        private SchoolManagementEntities _contexEntities =  null;
        public StudentManager()
        {
            _contexEntities = new SchoolManagementEntities();
        }

        public void Add(Student student)
        {
            _contexEntities.Students.Add(student);
            _contexEntities.SaveChanges();
        }

        public void Delete(int id)
        {
            Student student = _contexEntities.Students.Where(p => p.Id == id).FirstOrDefault();
            if (student != null)
            {
                _contexEntities.Students.Remove(student);
                _contexEntities.SaveChanges();
            }

        }

        public void Edit(Student student)
        {
            Student studentToUpdate = _contexEntities.Students.Where(p => p.Id == student.Id).FirstOrDefault();
            if (studentToUpdate != null)
            {
                studentToUpdate.Name = student.Name;
                studentToUpdate.Phone = student.Phone;
                studentToUpdate.Address = student.Address;
                _contexEntities.SaveChanges();
            }
        }

        public IEnumerable<Student> GetStudents()
        {
            return _contexEntities.Students.ToList();
        }
    }
}
