using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsDB.Models
{
    public class StudentInfos // Model class for student info
    {
        [Key]
        public int StdId { get; set; }
        // FirstName of the Std
        public string FirstName { get; set; }
        // LastName of the Std
        public string LastName { get; set; }
        // Gender of the student
        public string Gender { get; set; }
    }
}
