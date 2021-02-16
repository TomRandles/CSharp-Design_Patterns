namespace NullObject.Models
{
    public class Student : IStudent
    {
        public int Id { get; private set; }

        public string UserName { get; private set; }

        public int CoursesCompleted { get; private set; }

        public Student(int id, string userName, int coursesCompleted)
        { 
            Id = id;
            UserName = userName;
            CoursesCompleted = coursesCompleted;
        }
    }
}