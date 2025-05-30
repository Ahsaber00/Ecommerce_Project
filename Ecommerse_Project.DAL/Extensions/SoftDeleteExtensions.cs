using Ecommerse_Project.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ecommerse_Project.DAL.Extensions
{
    public static class SoftDeleteExtensions
    {
        public static void SoftDelete<T>(this DbSet<T> dbSet, T entity) where T : BaseEntity
        {
            entity.IsDeleted = true;
            entity.DeletedAt = DateTime.UtcNow;
            dbSet.Update(entity);
        }

        public static void SoftDeleteRange<T>(this DbSet<T> dbSet, IEnumerable<T> entities) where T : BaseEntity
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
                entity.DeletedAt = DateTime.UtcNow;
            }
            dbSet.UpdateRange(entities);
        }
    }
}