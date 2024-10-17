using System.Xml;
using System.Xml.Linq;
using Share.DTOs;

namespace WebApplication1.Services
{
    public class XmlFileReader
    {
        public List<DictionaryDto> ReadFromXmlStream(Stream xmlStream)
        {
            var items = new List<DictionaryDto>();
            try
            {
                using (var reader = XmlReader.Create(xmlStream))
                {
                    var xdoc = XDocument.Load(reader);
                    foreach (var element in xdoc.Descendants("zap"))
                    {
                        var idValue = element.Element("IDCZ")?.Value;
                        var nameValue = element.Element("N_CZ")?.Value;
                        var beginDateValue = element.Element("DATEBEG")?.Value;
                        var endDateValue = element.Element("DATEEND")?.Value;

                        DateTime endDate = DateTime.MaxValue;

                        if (int.TryParse(idValue, out int id) && DateTime.TryParse(beginDateValue, out DateTime beginDate))
                        {
                            if (!string.IsNullOrEmpty(endDateValue) && !DateTime.TryParse(endDateValue, out endDate))
                            {
                                throw new ArgumentException($"Invalid end date: {endDateValue}");
                            }

                            var item = new DictionaryDto
                            {
                                Id = id,
                                Name = nameValue ?? string.Empty,
                                BeginDate = DateTime.SpecifyKind(beginDate, DateTimeKind.Utc),
                                EndDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc)
                            };
                            items.Add(item);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid data in XML: IDCZ={idValue}, N_CZ={nameValue}, DATEBEG={beginDateValue}, DATEEND={endDateValue}");
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
    }
}
