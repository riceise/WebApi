using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Model.Entities.Dictionary;

namespace Data.Model.Entities.Invoice
{
    [Table(name: "Invoices", Schema = "inv")]
    public class Invoice:BaseEntity
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
        [Display(Name = "Ключ к MainInvoice")]
        public int MainInvoiceId { get; set; }
        public virtual MainInvoice? MainInvoice { get; set; }
        [MaxLength(20)]
        [Display(Name = "Номер счета")]
        public string InvNumber { get; set; } = string.Empty;
        [Display(Name = "Количество записей в реестре")]
        public int RecordsNumber { get; set; }
        [MaxLength(5)]
        [Display(Name = "Версия файла")]
        public string Version { get; set; } = string.Empty;
        [Display(Name = "Id типа диспансеризации")]
        public int TypeDispId { get; set; }
        public virtual TypeDisp? TypeDisp { get; set; }
        [Display(Name ="Тип файла")]
        public int InvoiceFileTypeId { get; set; }
        public virtual InvoiceFileType? InvoiceFileType { get; set; }
    }
}