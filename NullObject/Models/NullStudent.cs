using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject.Models
{
    public class NullStudent : IStudent
    {
        public int Id { get; } = -1;

        public string UserName => "Null value";

        public int CoursesCompleted { get; } = 0;
    }
}