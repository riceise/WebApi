using Data.Model;
using Share.DTOs;
using WebApplication1.Repositories;
using WebApplication1.Mappers;
using Data;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Services
{
    public class DictionaryService : IDictionaryService
    {
        private readonly DictionaryItemRepository _context;

        public DictionaryService(DictionaryItemRepository repository)
        {
            _context = repository;
        }

        public async Task<IEnumerable<DictionaryDto>> GetAllAsync()
        {
             var items = await _context.DictionaryItems.ToListAsync();
             return items.Select(item => item.ToDictionaryDto());
        }

        public async Task<DictionaryDto?> GetByIdAsync(int id)
        {
            var item = await _context.GetByKeyAsync(id);
            return item?.ToDictionaryDto(); 
        }

        public async Task<DictionaryItem> AddAsync(CreateDictionaryRequestDto dto)
        {
            
            var newItem = new DictionaryItem
            {
                Name = dto.Name,
                BeginDate = dto.BeginDate.ToUniversalTime(),
                Code = dto.Code,
                EndDate = dto.EndDate.ToUniversalTime(),
            
            };
    
            _context.Add(newItem);
            await _context.SaveChangesAsync();
            
            return newItem;
        }

        public async Task UpdateAsync(UpdateDictionaryRequestDto dto)
        {
            var item = await _context.GetByKeyAsync(dto.Id);
            if (item == null)
            {
                throw new KeyNotFoundException("Item not found");
            }
            item.Name = dto.Name;
            item.BeginDate = dto.BeginDate;
            item.Code = dto.Code;
            item.EndDate = dto.EndDate;

            _context.Edit(item);
            await _context.SaveChangesAsync(); 
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.GetByKeyAsync(id);
            if (item == null)
            {
                throw new KeyNotFoundException("Item not found");
            }
            _context.Delete(item);
            await _context.SaveChangesAsync(); 
        }
    

    }
}
