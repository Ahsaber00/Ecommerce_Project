using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerse_Project.DAL.Dbcontext;
using Ecommerse_Project.DAL.Entities;
using Ecommerse_Project.DAL.Interfaces;

namespace Ecommerse_Project.DAL.Repositories
{
    public class AccountReposatory:GenericRepository<ApplicationUser>,  IaccountReposatory
    {
        public AccountReposatory(ApplicationContext _context) : base(_context) { }
    }
}
