using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsDB.Models
{
    public class Courses // model class for courses
    {
        [Key] // unique key
        public int CID { get; set; }
        // course name
        public string CourseName { get; set; }
        // description fo the course
        public string Description { get; set; }

    }
}
