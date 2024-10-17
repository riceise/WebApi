using Data.Model;
using Share.DTOs;

namespace WebApplication1.Mappers
{
    public static class DictionaryMappers
    {
        public static DictionaryDto ToDictionaryDto(this DictionaryItem itemModel)
        {
            return new DictionaryDto
            {
                Id = itemModel.Id,
                Name = itemModel.Name,
                BeginDate = itemModel.BeginDate,
                Code = itemModel.Code,
                Comments = itemModel.Comments,
                EndDate = itemModel.EndDate
            };
        }

        public static DictionaryItem ToDictionaryItemCreateDto(this CreateDictionaryRequestDto DictionaryDto)
        {
            return new DictionaryItem
            {
                Name = DictionaryDto.Name,
                BeginDate = DictionaryDto.BeginDate,
                Code = DictionaryDto.Code,
                EndDate = DictionaryDto.EndDate
            };
        }
        
    }
}