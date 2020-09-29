using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentsDB.Models;

namespace StudentsDB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<StudentsDB.Models.StudentInfos> StudentInfos { get; set; }
        public DbSet<StudentsDB.Models.Courses> Courses { get; set; }
        public DbSet<StudentsDB.Models.Address> Address { get; set; }
    }
}
