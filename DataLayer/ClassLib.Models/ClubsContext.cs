
using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataLayer.ClassLib.Models;
using DataLayer;

namespace ClassLib.Models
{
    public class ClubsContext : DbContext
    {
        public ClubsContext() :base()
        {
            
        }
        public ClubsContext(DbContextOptions<ClubsContext> options)
            : base(options)
        {
            // Ensure Migrations are updated before seeding or using this context
        }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<ClubEvent> ClubEvents { get; set; }

        public DbSet<EventAttendnace> EventAttendances { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Student> Students { get; set; }


        public void Seed(string contentRootPath)
        {
            // Get the students from the CSV file in the Data folder of the Project that refrences this assembly
            if (!this.Students.Any())
            {
                var filepath = Path.Combine(contentRootPath, "Data\\StudentList1.csv");
                var students = DBHelper.GetFile<Student,StudentMap>(filepath);
                this.Students.AddRange(students);
                this.SaveChanges();
            }
            // Get the clubs from the DataLayer sub-assembly (Referenced Project)
            if (!this.Clubs.Any())
            {
                var clubs = DBHelper.GetResource<Club, ClubMap>("DataLayer.Data.Clubs.csv","DataLayer");
                this.Clubs.AddRange(clubs);
                this.SaveChanges();
            }
        }

       
    }

   
}
