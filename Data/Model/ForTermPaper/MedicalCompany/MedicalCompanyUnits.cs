using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Model.ForTermPaper.MedicalCompany
{
    [Table(name: "MedicalCompanyUnits", Schema = "LPU")]
    [Index(nameof(MedicalCompanyId))]
    public class MedicalCompanyUnit : BaseEntity
    {
        [Display(Name = "ЛПУ")]
        public int MedicalCompanyId { get; set; }
        public virtual ForTermPaper.MedicalCompany.MedicalCompany? MedicalCompany { get; set; }
        [Display(Name = "КОД ПОДРАЗД")]
        [MaxLength(20)]
        public string Code { get; set; } = string.Empty;
        [Display(Name = "СТАРЫЙ КОД")]
        [MaxLength(20)]
        public string OldCode { get; set; } = string.Empty;
        [MaxLength(20)]
        public string CodeMain { get; set; } = string.Empty;
        [Display(Name = "НАИМЕНОВАНИЕ")]
        public string Name { get; set; } = string.Empty;
        [MaxLength(50)]
        public string FRMOId { get; set; } = string.Empty;
        [Column(TypeName = "date")]
        [Display(Name = "НАЧАЛО")]
        public DateTime BeginDate { get; set; }
        [Display(Name = "ОКОНЧАНИЕ")]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
    }
}