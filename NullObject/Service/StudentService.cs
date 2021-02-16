using NullObject.Models;
using System.Collections.Generic;
using System.Linq;

namespace NullObject.Service
{
    public class StudentService
    {
        readonly StudentRepo _repo = new StudentRepo();

        public IStudent GetCurrentStudent()
        {
            int studentId = 0;

            return _repo.GetStudent(studentId);
        }

        class StudentRepo
        {
            readonly IList<Student> _students = new List<Student>();

            internal StudentRepo()
            {
                _students.Add(new Student(1, "David", 83));
                _students.Add(new Student(2, "Julie", 72));
                _students.Add(new Student(3, "Scott", 92));
            }

            internal IStudent GetStudent(int id)
            {
                bool studentExists = _students.Any(l => l.Id == id);

                if (studentExists)
                    return _students.FirstOrDefault(l => l.Id == id);

                return new NullStudent();
            }
        }
    }
}