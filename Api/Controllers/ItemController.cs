using Microsoft.AspNetCore.Mvc;
using Share.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("Api")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IDictionaryService _dictionaryService;


        public ItemController(IDictionaryService dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dictionaryItems = await _dictionaryService.GetAllAsync();
            return Ok(dictionaryItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var dictionaryItem = await _dictionaryService.GetByIdAsync(id);
            if (dictionaryItem == null)
            {
                return NotFound();
            }

            return Ok(dictionaryItem);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDictionaryRequestDto createDto) 
        {
            await _dictionaryService.AddAsync(createDto); 
        
            return CreatedAtAction(nameof(GetById), new { id = createDto.Id }, createDto); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateDictionaryRequestDto updateDto) 
        {
            var existingItem = await _dictionaryService.GetByIdAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            updateDto.Id = id;

            await _dictionaryService.UpdateAsync(updateDto); 
            return Ok(updateDto); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var existingItem = await _dictionaryService.GetByIdAsync(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            await _dictionaryService.DeleteAsync(id);
            return NoContent();
        }
    }
}

