using ClassLib.Models;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ClassLib.Models
{
    internal class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            //Map(m => m.ID).Name("ID");
            Map(m => m.StudentID).Index(0);
            Map(m => m.FirstName).Index(1);
            Map(m => m.SecondName).Index(2);

        }
    }
}
