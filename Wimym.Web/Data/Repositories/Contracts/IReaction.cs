namespace Wimym.Web.Data.Repositories.Contracts
{
    using System.Linq;
    using System.Threading.Tasks;
    using Wimym.Web.Data.Entities;

    public interface IReaction : IRepository<Reaction>
    {
        IQueryable GetAllWithUsers();
        Task<IQueryable<Reaction>> GetReactionsAsync(string userName);

        Task CreateReactionAsync(Reaction model, string userName);
        //IEnumerable<SelectListItem> GetComboProducts();
    }
}
