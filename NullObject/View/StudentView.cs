using NullObject.Models;
using System;

namespace NullObject.View
{
    public class StudentView
    {
        private readonly IStudent _student;

        public StudentView(IStudent student)
        {
            _student = student;
        }

        public void RenderView()
        {
            Console.WriteLine("User Name: " + _student.UserName);
            Console.WriteLine("Courses Completed: " + _student.CoursesCompleted);
        }
    }
}
