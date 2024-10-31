using System.ComponentModel.DataAnnotations;

//using Data.Model.Entities.Dictionary;

namespace Data.Model.ForTermPaper
{
    public class Policy : BaseEntity
    {
        [Display(Name ="Id человека")]
        public Guid PersonId { get; set; }

        [Display(Name = "Ссылка на объект Person")]
        public virtual Person.Person? Person { get; set; }

        [Display(Name = "Тип полиса")]
        public int PolicyTypeId { get; set; }
        [Display(Name = "Ссылка на объект PolicyType")]
        public virtual PolicyType? PolicyType { get; set; }
        [MaxLength(10)]
        [Display(Name = "Серия полиса")]
        public string Series { get; set; } = string.Empty;
        [MaxLength(16)]
        [Display(Name = "Номер полиса")]
        public string Number { get; set; } = string.Empty;
        [MaxLength(16)]
        [Display(Name = "ЕНП")]
        public string ENP { get; set; } = string.Empty;
        [MaxLength(10)]
        [Display(Name = "Регион страхования")]
        public string OKATO { get; set; } = string.Empty;
        [Display(Name = "Id страховой компании")]
        public int InsuranceCompanyId { get; set; }
    }

    public class PolicyType
    {
    }
}