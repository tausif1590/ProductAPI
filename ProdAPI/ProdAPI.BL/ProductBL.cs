using EmpAPI.DAL.Interface;
using ProdAPI.DB.CodeFirstMigration.Context;
using ProdAPI.Repository;


namespace ProdAPI.BL
{
    public class ProductBL : IGenericBL<Product>
    {
        private readonly IGenericRepository<Product> _productRepo;
        public ProductBL(IGenericRepository<Product> productRepo)
        {
                _productRepo = productRepo;
        }

        public async Task<bool> Add(Product product)
        {
           return await _productRepo.Add(product);
        }

        public async Task<bool> Update(Product product)
        {
            return await _productRepo.UpdateEntity(product);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepo.GetAll();
        }

        public async Task<Product?> GetById(long id)
        {
            return await _productRepo.Get(id); 
        }

        public async Task<bool> Delete(long id)
        {
            return await _productRepo.DeleteEntity(id);
        }

        public async Task<bool> StockUpdate(long id, long quantity)
        {
            Product? existing = await _productRepo.Get(id);
            bool rowsAffected = false;
            if (existing != null)
            {
                existing.Quantity += (quantity);
                existing.UtcUpdatedOn = DateTime.UtcNow;
                rowsAffected = await _productRepo.UpdateEntity(existing);
            }
            return rowsAffected;
        }
    }
}
