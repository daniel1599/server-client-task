using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server_side_app.Models
{
    public class ClassItem
    {
        public long Id { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public string StudentsNames { get; set; }
    }
}
