
using System.ComponentModel.DataAnnotations;
namespace Share.DTOs;

public class DictionaryDto : BaseDto
{
    public int Id { get; set; }
    
    [DisplayFormat(DataFormatString = "{0:d}")]
    [Display(Name = "Начало")]
    public DateTime BeginDate { get; set; }

    [DisplayFormat(DataFormatString = "{0:d}")]
    [Display(Name = "Окончание")]
    public DateTime EndDate { get; set; }

    [Display(Name = "Код")] 
    public string Code { get; set; } = string.Empty;
    [Display(Name = "Наименование")] 
    public string Name { get; set; } = string.Empty;
   
    public string Comments { get; set; } = string.Empty;
    
    public DictionaryDto()
    {
        BeginDate = DateTime.MaxValue;
        EndDate = DateTime.MaxValue;
    }
}