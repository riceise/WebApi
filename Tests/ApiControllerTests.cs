using Data.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Share.DTOs;
using WebApplication1.Controllers;
using WebApplication1.Services;
using Xunit;

namespace Tests
{
    public class ItemControllerTests
    {
        private readonly Mock<IDictionaryService> _mockService;
        private readonly ItemController _controller;

        public ItemControllerTests()
        {
            _mockService = new Mock<IDictionaryService>();
            _controller = new ItemController(_mockService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfDictionaryDto()
        {
            // Arrange
            var dictionaryItems = new List<DictionaryDto>
            {
                new DictionaryDto 
                { 
                    Id = 1,
                    Name = "Item 1",
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1), 
                    Code = "Code" 
                },
                new DictionaryDto
                {
                    Id = 2,
                    Name = "Item 2", 
                    BeginDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(1),
                    Code = "code 2"
                }
            };
            _mockService.Setup(service => service.GetAllAsync())
                .ReturnsAsync(dictionaryItems);

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedItems = Assert.IsAssignableFrom<IEnumerable<DictionaryDto>>(okResult.Value);
            Assert.Equal(dictionaryItems.Count, returnedItems.Count());
        }

        [Fact]
        public async Task GetById_ExistingId_ReturnsOkResult_WithDictionaryDto()
        {
            // Arrange
            var itemId = 1;
            var dictionaryItem = new DictionaryDto
            {
                Id = itemId, 
                Name = "Item 1",
                BeginDate = DateTime.Now, 
                EndDate = DateTime.Now.AddDays(1),
                Code = "code 2"
            };
            _mockService.Setup(service => service.GetByIdAsync(itemId))
                .ReturnsAsync(dictionaryItem);

            // Act
            var result = await _controller.GetById(itemId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedItem = Assert.IsType<DictionaryDto>(okResult.Value);
            Assert.Equal(itemId, returnedItem.Id);
        }

        [Fact]
        public async Task GetById_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var itemId = 99;
            _mockService.Setup(service => service.GetByIdAsync(itemId))
                .ReturnsAsync((DictionaryDto)null);

            // Act
            var result = await _controller.GetById(itemId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_ValidDto_ReturnsCreatedAtAction_WithCreatedItem()
        {
            // Arrange
            var createDto = new CreateDictionaryRequestDto 
            { 
                Name = "New Item", 
                BeginDate = DateTime.Now, 
                EndDate = DateTime.Now.AddDays(1), 
                Code = "New code" 
            };
            var createdItem = new DictionaryItem 
            { 
                Id = 1, 
                Name = createDto.Name, 
                BeginDate = createDto.BeginDate, 
                EndDate = createDto.EndDate, 
                Code = createDto.Code 
            };
            _mockService.Setup(service => service.AddAsync(createDto))
                .ReturnsAsync(createdItem);

            // Act
            var result = await _controller.Create(createDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(ItemController.GetById), createdAtActionResult.ActionName);
            Assert.Equal(createdItem.Id, createdAtActionResult.RouteValues["id"]);
            var returnedItem = Assert.IsType<DictionaryItem>(createdAtActionResult.Value);
            Assert.Equal(createdItem.Id, returnedItem.Id);
        }

        [Fact]
        public async Task Update_ExistingId_ValidDto_ReturnsOkResult_WithUpdatedDto()
        {
            // Arrange
            var itemId = 1;
            var updateDto = new UpdateDictionaryRequestDto
            {
                Id = itemId,
                Name = "Updated Item",
                BeginDate = DateTime.Now.AddDays(2),
                EndDate = DateTime.Now.AddDays(3),
                Code = "Updated code"
            };
            var existingItem = new DictionaryItem
            {
                Id = itemId,
                Name = "Item 1",
                BeginDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Code = "Code"
            };
            _mockService.Setup(service => service.GetByIdAsync(itemId))
                .ReturnsAsync(new DictionaryDto 
                { 
                    Id = existingItem.Id, 
                    Name = existingItem.Name, 
                    BeginDate = existingItem.BeginDate, 
                    EndDate = existingItem.EndDate, 
                    Code = existingItem.Code 
                }); 
            _mockService.Setup(service => service.UpdateAsync(updateDto))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Update(itemId, updateDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedDto = Assert.IsType<UpdateDictionaryRequestDto>(okResult.Value);
            Assert.Equal(updateDto.Name, returnedDto.Name);
            Assert.Equal(updateDto.BeginDate, returnedDto.BeginDate);
            Assert.Equal(updateDto.EndDate, returnedDto.EndDate);
            Assert.Equal(updateDto.Code, returnedDto.Code);
        }

        [Fact]
        public async Task Update_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var itemId = 99;
            var updateDto = new UpdateDictionaryRequestDto
            {
                Id = itemId,
                Name = "Updated Item",
                BeginDate = DateTime.Now.AddDays(2),
                EndDate = DateTime.Now.AddDays(3),
                Code = "Updated ccode"
            };
            _mockService.Setup(service => service.GetByIdAsync(itemId))
                .ReturnsAsync((DictionaryDto)null);

            // Act
            var result = await _controller.Update(itemId, updateDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ExistingId_ReturnsNoContent()
        {
            // Arrange
            var itemId = 1;
            _mockService.Setup(service => service.GetByIdAsync(itemId))
                .ReturnsAsync(new DictionaryDto
                {
                    Id = itemId, 
                    Name = "Item 1",
                    BeginDate = DateTime.Now, 
                    EndDate = DateTime.Now.AddDays(1), 
                    Code = "CCode"
                });
            _mockService.Setup(service => service.DeleteAsync(itemId))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(itemId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var itemId = 99;
            _mockService.Setup(service => service.GetByIdAsync(itemId))
                .ReturnsAsync((DictionaryDto)null);

            // Act
            var result = await _controller.Delete(itemId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
