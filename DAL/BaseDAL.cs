using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public abstract class BaseDAL<TDbContext, TEntity, TObjectId>
        where TDbContext : DbContext, new()
        where TEntity : class
    {
        protected TDbContext? _context;

        protected BaseDAL()
        {
        }

        protected BaseDAL(TDbContext context)
        {
            _context = context;
        }

        public Task<TObjectId> AddOrUpdateAsync(TEntity entity)
        {
            return AddOrUpdateAsync(entity, true);
        }
        internal async Task<TObjectId> AddOrUpdateAsync(TEntity entity, bool forceSave)
        {
            var data = GetContext();
            try
            {
                var objects = data.Set<TEntity>();
                objects.Add(entity);
                if (forceSave)
                {
                    await data.SaveChangesAsync();
                }
                return GetIdByEntity(entity);
            }
            finally
            {
                await DisposeContextAsync(data);
            }
        }

        protected abstract Expression<Func<TEntity, TObjectId>> GetIdByEntityExpression();

        protected TObjectId GetIdByEntity(TEntity entity)
        {
            return GetIdByEntityExpression().Compile()(entity);
        }

        protected TDbContext GetContext()
        {
            if (_context != null)
                return _context;
            else 
                return new TDbContext();
        }

        protected async Task<bool> DisposeContextAsync(TDbContext context)
        {
            if (ReferenceEquals(context, _context)) return false;
            await context.DisposeAsync();
            return true;
        }
    }
}
