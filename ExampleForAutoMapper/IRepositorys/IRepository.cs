namespace ExampleForAutoMapper.IRepositorys
{
    public interface IRepository<T> 
    {
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(int id , T entity);
        Task<T> DeleteAsync(int id);
    }
}
