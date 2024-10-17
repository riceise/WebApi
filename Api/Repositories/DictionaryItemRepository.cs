using Data.Model; 

using Data;

namespace WebApplication1.Repositories
{
    public class DictionaryItemRepository : GenericRepository<DictionaryItem>
    {
        public DictionaryItemRepository(ApplicationDbContext context) : base(context) { }
        
        public IQueryable<DictionaryItem> DictionaryItems => GetAll();
    }
}