using ClassLib.Models;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ClassLib.Models
{
    internal class ClubMap : ClassMap<Club>
    {
        public ClubMap()
        {
            //Map(m => m.ClubId).Index(0);
            Map(m => m.ClubName).Index(1);
            Map(m => m.CreationDate).TypeConverterOption.Format("dd/MM/yyyy").Index(2);
            Map(m => m.adminID).Index(3);

        }
    }
}
