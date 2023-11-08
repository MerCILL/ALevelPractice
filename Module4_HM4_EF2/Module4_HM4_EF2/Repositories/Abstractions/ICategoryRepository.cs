using Module4_HM4_EF2.DbData.Models;
using static Module4_HM4_EF2.Repositories.Abstractions.IRepository;

namespace Module4_HM4_EF2.Repositories.Abstractions
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetByNameAsync(string name);
    }
}
