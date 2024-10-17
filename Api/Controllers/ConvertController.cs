
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Services;
using Share.DTOs;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        private readonly IDictionaryServicesConvert _convertService;

        public ConvertController(IDictionaryServicesConvert convertService)
        {
            _convertService = convertService;
        }

        [HttpPost("UploadXml")]
        public async Task<IActionResult> UploadXml(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Файл не выбран или пустой.");
            }

            try
            {
                var dictionaryItems = await _convertService.ReadFromXmlAsync(file);
                await _convertService.SaveToDatabaseAsync(dictionaryItems);
                return Ok(dictionaryItems); 
            }
            catch (DbUpdateException dbEx)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ошибка базы данных: {dbEx.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ошибка: {ex.Message}");
            }
        }
    }
}
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Http;
// using WebApplication1.Services;
//
// namespace WebApplication1.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class ConvertController : ControllerBase
//     {
//         private readonly XmlFileReader _xmlFileReader;
//         private readonly DictionaryService _dictionaryService;
//
//         public ConvertController(XmlFileReader xmlFileReader, DictionaryService dictionaryService)
//         {
//             _xmlFileReader = xmlFileReader;
//             _dictionaryService = dictionaryService;
//         }
//
//         [HttpPost("UploadXml")]
//         public async Task<IActionResult> UploadXml(IFormFile file)
//         {
//             if (file == null || file.Length == 0)
//             {
//                 return BadRequest("Файл не выбран или пустой.");
//             }
//
//             try
//             {
//                 using (var stream = file.OpenReadStream())
//                 {
//                     var dictionaryItems = _xmlFileReader.ReadFromXmlStream(stream);
//                     await _dictionaryService.SaveDictionaryItemsAsync(dictionaryItems);
//                 }
//
//                 return Ok("Данные успешно сохранены.");
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(StatusCodes.Status500InternalServerError, $"Ошибка: {ex.Message}");
//             }
//         }
//     }
// }
