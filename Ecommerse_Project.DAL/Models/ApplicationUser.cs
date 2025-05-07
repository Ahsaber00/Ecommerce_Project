using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerse_Project.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Ecommerse_Project.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public UserRole Role { get; set; }
        [AllowNull]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<Address>? Address { get; set; }
    }
}
