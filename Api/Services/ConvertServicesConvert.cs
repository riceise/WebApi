﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Data;
using Share.DTOs;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Services
{
    public class ConvertServicesConvert : IDictionaryServicesConvert
    {
        private readonly ApplicationDbContext _context;

        public ConvertServicesConvert(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<DictionaryDto> ReadFromXml(string filePath)
        {
            throw new NotImplementedException("Use ReadFromXmlAsync with IFormFile instead.");
        }

        public async Task<List<DictionaryDto>> ReadFromXmlAsync(IFormFile file)
        {
            var items = new List<DictionaryDto>();
            try
            {
                using (var stream = file.OpenReadStream())
                using (var reader = System.Xml.XmlReader.Create(stream))
                {
                    var xdoc = XDocument.Load(reader);
                    foreach (var element in xdoc.Descendants("zap"))
                    {
                        var codeValue = element.Element("IDCZ")?.Value; 
                        var nameValue = element.Element("N_CZ")?.Value;
                        var beginDateValue = element.Element("DATEBEG")?.Value;
                        var endDateValue = element.Element("DATEEND")?.Value;

                        DateTime endDate = DateTime.MaxValue;

                        if (DateTime.TryParse(beginDateValue, out DateTime beginDate))
                        {
                            if (!string.IsNullOrEmpty(endDateValue) && !DateTime.TryParse(endDateValue, out endDate))
                            {
                                throw new ArgumentException($"Invalid end date: {endDateValue}");
                            }

                            var item = new DictionaryDto
                            {
                                Code = codeValue ?? string.Empty, 
                                Name = nameValue ?? string.Empty,
                                BeginDate = DateTime.SpecifyKind(beginDate, DateTimeKind.Utc),
                                EndDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc)
                            };
                            items.Add(item);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid data in XML: IDCZ={codeValue}, N_CZ={nameValue}, DATEBEG={beginDateValue}, DATEEND={endDateValue}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Error reading XML file: {e.Message}");
            }

            return items;
        }

        public async Task SaveToDatabaseAsync(List<DictionaryDto> dictionaryItems)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.DictionaryItems.ExecuteDeleteAsync();

    

                const int batchSize = 100;
                for (int i = 0; i < dictionaryItems.Count; i += batchSize)
                {
                    var batch = dictionaryItems.Skip(i).Take(batchSize).Select(dto => new DictionaryItem
                    {

                        BeginDate = dto.BeginDate,
                        EndDate = dto.EndDate,
                        Name = dto.Name,
                        Code = dto.Code 
                    }).ToList();

                    _context.DictionaryItems.AddRange(batch);
                    await _context.SaveChangesAsync();
                }

                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}