using Microsoft.EntityFrameworkCore;

namespace Ecommerse_Project.DAL.Dbcontext
{
    public interface IQueryFilter
    {
        void Apply(ModelBuilder modelBuilder);
    }
}