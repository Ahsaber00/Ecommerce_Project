using Ecommerse_Project.DAL.Dbcontext;
using Ecommerse_Project.DAL.Entities;
using Ecommerse_Project.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IProductRepository Products { get; }

        public ICategoryRepository Categories { get; }

        public IImageRepository Images { get; }
        public IaccountReposatory Accounts { get; }
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Categories = new CategoryRepository(_context);
            Images = new ImageRepository(_context);
            Accounts = new AccountReposatory(_context);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
