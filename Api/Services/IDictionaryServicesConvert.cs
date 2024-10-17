using Share.DTOs;

namespace WebApplication1.Services
{
    public interface IDictionaryServicesConvert
    {
        List<DictionaryDto> ReadFromXml(string filePath); 
        Task<List<DictionaryDto>> ReadFromXmlAsync(IFormFile file); 
        Task SaveToDatabaseAsync(List<DictionaryDto> dictionaryItems);
    }
}



