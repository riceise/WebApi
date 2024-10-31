using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Model.Entities.Dictionary;

namespace Data.Model.Entities.Invoice
{

    [Table(name: "MainInvoices",Schema ="inv")]
    public class MainInvoice:BaseEntity
    {
        [Display(Name = "Медицинская организация")]
        public int MedicalCompanyId { get; set; }
        public virtual ForTermPaper.MedicalCompany.MedicalCompany? MedicalCompany { get; set; }
        [Display(Name = "Дата получения файла реестров-счетов")]
        public DateTime InvDate { get; set; }
        [Display(Name = "Выставленная сумма")]
        public decimal TotalSum { get; set; }
        [Display(Name = "Сумма санкций")]
        public decimal SankSum { get; set; }
        [Display(Name = "Сумма к оплате")]
        public decimal PaySum { get; set; }
        [MaxLength(50)]
        [Display(Name = "Наименование загруженного файла")]
        public string FileName { get; set; } = string.Empty;

        [Display(Name ="Id партии")]
        public int BatchNumberId { get; set; }
        public virtual BatchNumber? BatchNumber { get; set; }
        [Display(Name = "Номер недели")]
        public int WeekNumber {  get; set; }
        [Display(Name = "Период")]
        public int Period { get; set; }
        [Display(Name = "Год")]
        public int Year { get; set; }
    }
}