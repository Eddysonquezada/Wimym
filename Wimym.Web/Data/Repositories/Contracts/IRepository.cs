namespace Wimym.Web.Data.Repositories.Contracts
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll(string user);

        Task<T> GetByIdAsync(int id);

        //Task CreateAsync(T entity);

        //Task UpdateAsync(T entity);
        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);


        Task DeleteAsync(T entity);

        Task<bool> ExistAsync(int id);
    }
}
