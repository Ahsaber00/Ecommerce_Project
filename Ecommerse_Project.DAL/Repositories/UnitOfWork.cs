using Ecommerse_Project.DAL.Dbcontext;
using Ecommerse_Project.DAL.Entities;
using Ecommerse_Project.DAL.Interfaces;
using StackExchange.Redis;
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
        private readonly IConnectionMultiplexer _redis;
        public IProductRepository Products { get; }

        public ICategoryRepository Categories { get; }

        public IImageRepository Images { get; }
        public IaccountReposatory Accounts { get; }

        public ICartRepository CustomerCart { get; }

        public UnitOfWork(ApplicationContext context, IConnectionMultiplexer redis)
        {
            _redis=redis;
            _context = context;
            Products = new ProductRepository(_context);
            Categories = new CategoryRepository(_context);
            Images = new ImageRepository(_context);
            Accounts = new AccountReposatory(_context);
            CustomerCart = new CartRepository(_redis);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
