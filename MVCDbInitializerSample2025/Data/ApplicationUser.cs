using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDbInitializerSample2025.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
