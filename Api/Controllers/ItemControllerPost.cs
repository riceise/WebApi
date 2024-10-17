// using Data;
// using Data.Model;
// using Microsoft.AspNetCore.Mvc;
// using Share.DTOs;
// using WebApplication1.Mappers;
//
// namespace WebApplication1.Controllers
// {
//     [Route("Api")]
//     [ApiController]
//     public class ItemControllerPost : ControllerBase
//     {
//         private readonly ApplicationDbContext _context;
//
//         public ItemControllerPost(ApplicationDbContext context)
//         {
//             _context = context;
//         }
//
//         [HttpGet("{id}")]
//         [ApiExplorerSettings(IgnoreApi = true)]  
//         
//         public IActionResult GetById([FromRoute] int id)
//         {
//             var dictionaryItem = _context.DictionaryItems.Find(id);
//             if (dictionaryItem == null)
//             {
//                 return NotFound();
//             }
//         
//             return Ok(dictionaryItem.ToDictionaryDto());
//         }
//
//         [HttpPost]
//         public IActionResult Create([FromBody] CreateDictionaryRequestDto DictionaryDto)
//         {
//             var DictionaryItemModel = DictionaryDto.ToDictionaryItemCreateDto();
//             _context.DictionaryItems.Add(DictionaryItemModel);
//             _context.SaveChanges();
//             return CreatedAtAction(nameof(GetById), new { id = DictionaryItemModel.Id },
//                 DictionaryItemModel.ToDictionaryDto());
//         }
//     }
//
// }