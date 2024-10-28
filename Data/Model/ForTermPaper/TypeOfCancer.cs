using System.ComponentModel.DataAnnotations;

namespace Data.Model.ForTermPaper
{
    public class TypeOfCancer
    {
        public int Id { get; set; }

        [Display(Name = "Код онкологического заболевания")]
        public int Code { get; set; }
        
        [Display(Name = "Тип онкологического заболевания")]
        public string? TypeCenser { get; set; }
    }
}
