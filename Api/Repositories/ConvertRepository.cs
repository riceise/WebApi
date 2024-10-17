using Data;
using Data.Model;
using WebApplication1.Repositories;

namespace WebApplication1.Repositories
{
    public class DictionaryRepository : GenericRepository<DictionaryItem>
    {
        public DictionaryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}