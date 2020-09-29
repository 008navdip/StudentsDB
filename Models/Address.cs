using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsDB.Models
{
    public class Address // model class address
    {
        [Key] // address id
        public int AddrId { get; set; }
        // name of the student
        public string Name { get; set; }
        [DisplayName("Address")]
        // address of the student
        public string Addr { get; set; }
    }
}
