﻿using Share.DTOs;

namespace WebApplication1.Services
{
    public interface IDictionaryService
    {
        Task<IEnumerable<DictionaryDto>> GetAllAsync();
        Task<DictionaryDto?> GetByIdAsync(int id);
        Task AddAsync(CreateDictionaryRequestDto dto);  
        Task UpdateAsync(UpdateDictionaryRequestDto dto);
        Task DeleteAsync(int id);
    }
}