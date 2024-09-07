using EmpAPI.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using ProdAPI.DB.CodeFirstMigration.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProdAPI.Repository
{
    public class ProductRepo : IGenericRepository<Product>
    {
        private readonly ProdDBContext _db;
        public ProductRepo(ProdDBContext db)
        {
            _db = db;
        }

        public async Task<bool> Add(Product entity)
        {
            entity.UtcUpdatedOn = DateTime.UtcNow;
            entity.IsActive = true;
            _db.Products.Add(entity);
            int rowAffected = await _db.SaveChangesAsync();
            return rowAffected > 0; 
        }

        public async Task<bool> DeleteEntity(long id)
        {
            Product? existing = await  _db.Products.FindAsync(id);
            int rowAffected = 0;
            if (existing != null) {
                _db.Products.Remove(existing);
                rowAffected+= await _db.SaveChangesAsync();
            }
            return rowAffected > 0;
        }

        public async Task<Product?> Get(long id)
        {
            return await _db.Products.FindAsync(id);

        }

        public async Task<IEnumerable<Product>> GetAll(Expression<Func<Product, bool>> filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null)
        {
            return await _db.Products.AsNoTracking().ToListAsync();
        }

        public  async Task<bool> UpdateEntity(Product entity)
        {
            Product? existing = await _db.Products.FindAsync(entity.Id);
            int rowAffected = 0;
            if (existing != null)
            {
                existing.Description = entity.Description;
                existing.Name = entity.Name;
                existing.Quantity = entity.Quantity;
                existing.UtcUpdatedOn = DateTime.UtcNow;
                _db.Products.Update(existing);
                rowAffected += await _db.SaveChangesAsync();
            }
            return rowAffected > 0;
        }
    }
}
