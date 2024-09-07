namespace ProdAPI.BL
{
    public interface IGenericBL<T> where T : class
    {
        Task<T?> GetById(long id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Add(T product);
        Task<bool> Update(T product);
        Task<bool> StockUpdate(long id, long quantity);
        Task<bool> Delete(long id);
    }
}
