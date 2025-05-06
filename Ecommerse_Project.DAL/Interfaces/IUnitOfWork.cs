using Ecommerse_Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }
        public IImageRepository Images { get; }
        public IaccountReposatory Accounts { get; }
        public Task<bool> SaveAll();
    }
}
