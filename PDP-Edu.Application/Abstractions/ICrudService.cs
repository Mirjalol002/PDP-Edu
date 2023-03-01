namespace PDP_Edu.Application.Abstractions
{
    public interface ICrudService<T, V, C, U>
    {
        Task<V> GetByIdAsync(T id);
        Task<List<V>> GetAllAsync();
        Task CreateAsync(C entity);
        Task UpdateAsync(U entity);
        Task DeleteAsync(T id);
    }
}
