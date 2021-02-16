using NullObject.Models;
using NullObject.Service;
using NullObject.View;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentService studentService = new StudentService();
            IStudent student = studentService.GetCurrentStudent();

            StudentView view = new StudentView(student);
            view.RenderView();
        }
    }
}
