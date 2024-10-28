using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//using Data.Model.Entities.Common;

namespace Data.Model.ForTermPaper.Person
{
    [Table(name: "Persons")]
    public class Person
    {
        [MaxLength(36)]
        [Display(Name = "Id гражданина из ФЕРЗЛ")]
        public string PersonId { get; set; } = string.Empty;
        [MaxLength(50)]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; } = string.Empty;
        [MaxLength(50)]
        [Display(Name = "Имя")]
        public string Name1 { get; set; } = string.Empty;
        [MaxLength(50)]
        [Display(Name = "Отчество")]
        public string Name2 { get; set; } = string.Empty;
        [Display(Name = "Пол")]
        public int Sex { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; }
        [MaxLength(50)]
        [Display(Name = "СНИЛС")]
        public string SNILS { get; set; } = string.Empty;
        [MaxLength(16)]
        [Display(Name = "ЕНП")]
        public string ENP { get; set; } = string.Empty;
        [Display(Name = "Признак полной идентификации в ФЕРЗЛ")]
        public bool IsBad { get; set; }
        [MaxLength(256)]
        [Display(Name = "Хеш-код")]
        public string Hash { get; set; } = string.Empty;


    }
}