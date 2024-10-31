using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model.ForTermPaper.MedicalCompany
{
    [Table(name: "MedicalCompanies", Schema = "LPU")]
    public class MedicalCompany : BaseEntity
    {
        [MaxLength(45)]
        [Display(Name = "Код ФРМО")]
        public string FRMOId { get; set; } = string.Empty;

        [MaxLength(20)]
        [Display(Name = "Реестровый номер ФРМО")]
        public string ReestrNumber { get; set; } = string.Empty;

        [Display(Name = "Код ОКАТО")]
        public int OKATOId { get; set; }
        [MaxLength(6)]
        [Display(Name = "Код ЛПУ")]
        public string Code { get; set; } = string.Empty;

        [Display(Name = "Полное наименование ЛПУ")]
        public string FullName { get; set; } = string.Empty;
        [MaxLength(2500)]
        [Display(Name = "Сокр.наименование")]
        public string ShortName { get; set; } = string.Empty;
        [MaxLength(20)]
        [Display(Name = "ИНН")]
        public string INN { get; set; } = string.Empty;
        [MaxLength(15)]
        [Display(Name = "ОГРН")]
        public string OGRN { get; set; } = string.Empty;
        [MaxLength(10)]
        [Display(Name = "КПП")]
        public string KPP { get; set; } = string.Empty;
    }
}

