using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model.ForTermPaper.MedicalCompany
{

    [Table(name: "MedicalCompanyDepartments", Schema = "LPU")]
    public class MedicalCompanyDepartment : BaseEntity
    {
        [Display(Name = "ЛПУ")]
        public int MedicalCompanyId { get; set; }
        public virtual ForTermPaper.MedicalCompany.MedicalCompany? MedicalCompany { get; set; }
        public int MedicalCompanyUnitId { get; set; }
        public virtual MedicalCompanyUnit? MedicalCompanyUnit { get; set; }
        [Display(Name = "СТАРЫЙ КОД")]
        [MaxLength(20)]
        public string OldCode { get; set; } = string.Empty;
        [Display(Name = "КОД ОТДЕЛЕНИЯ")]
        [MaxLength(20)]
        public string Code { get; set; } = string.Empty;
        [Display(Name = "НАИМЕНОВАНИЕ")]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "date")]
        [Display(Name = "НАЧАЛО")]
        public DateTime BeginDate { get; set; }
        [Display(Name = "ОКОНЧАНИЕ")]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "ПРОФИЛЬ")]
        public int MedProfileId { get; set; }
        //public MedProfile? MedProfile { get; set; }
        [Display(Name = "УСЛОВ. ОКАЗАНИЯ")]
        public int UMPId { get; set; }
        //public UMP? UMP { get; set; }
        [Display(Name = "ВИД ПОМОЩИ")]
        public int VidPomId { get; set; }
        //public VidPom? VidPom { get; set; }
    }
}