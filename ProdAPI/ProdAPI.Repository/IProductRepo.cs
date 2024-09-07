using ProdAPI.DB.CodeFirstMigration.Context;

namespace ProdAPI.Repository
{
    public interface IProductRepo
    {
        Task<Product> GetById(long id);
        Task<List<Product>> GetAll();
        Task<bool> Update(Product product);
        Task<bool> Delete(Product product);
    }
}
