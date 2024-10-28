using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Share.DTOs;
using WebApplication1.Controllers;
using WebApplication1.Services;
using Xunit;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Tests
{
    public class UploadXmlTests
    {
        private readonly Mock<IDictionaryServicesConvert> _mockService;
        private readonly ConvertController _controller;

        public UploadXmlTests()
        {
            _mockService = new Mock<IDictionaryServicesConvert>();
            _controller = new ConvertController(_mockService.Object);
        }

        private Mock<IFormFile> CreateMockFile(string content, string fileName = "test.xml")
        {
            var fileMock = new Mock<IFormFile>();
            var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(content));

            fileMock.Setup(f => f.OpenReadStream()).Returns(memoryStream);
            fileMock.Setup(f => f.FileName).Returns(fileName);
            fileMock.Setup(f => f.Length).Returns(memoryStream.Length);

            return fileMock;
        }

        [Fact]
        public async Task UploadXml_ValidFile_ReturnsOkResult()
        {
            // Arrange
            var validXmlContent = @"
                <packet>
                    <zglv>
                        <type>C_ZAB</type>
                        <version>1.0</version>
                        <date>26.09.2018</date>
                    </zglv>
                    <zap>
                        <IDCZ>7</IDCZ>
                        <N_CZ>Острое</N_CZ>
                        <DATEBEG>01.09.2018</DATEBEG>
                        <DATEEND/>
                    </zap>
                </packet>";

            var fileMock = CreateMockFile(validXmlContent);
            var expectedDictionary = new List<DictionaryDto>
            {
                new DictionaryDto
                {
                    Code = "7",
                    Name = "Острое",
                    BeginDate = new DateTime(2018, 9, 1),
                    EndDate = DateTime.MaxValue
                }
            };

            _mockService.Setup(service => service.ReadFromXmlAsync(It.IsAny<IFormFile>()))
                        .ReturnsAsync(expectedDictionary);

            // Act
            var result = await _controller.UploadXml(fileMock.Object);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedDictionary, okResult.Value);
        }

        [Fact]
        public async Task UploadXml_NullFile_ReturnsBadRequest()
        {
            // Act
            var result = await _controller.UploadXml(null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Файл не выбран или пустой.", badRequestResult.Value);
        }

        [Fact]
        public async Task UploadXml_EmptyFile_ReturnsBadRequest()
        {
            // Arrange
            var emptyFileMock = new Mock<IFormFile>();
            emptyFileMock.Setup(f => f.OpenReadStream()).Returns(new MemoryStream());
            emptyFileMock.Setup(f => f.Length).Returns(0);

            // Act
            var result = await _controller.UploadXml(emptyFileMock.Object);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Файл не выбран или пустой.", badRequestResult.Value);
        }
    }
}
