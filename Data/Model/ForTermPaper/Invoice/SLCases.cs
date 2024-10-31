using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Model.ForTermPaper.Common;
using Data.Model.ForTermPaper.MedicalCompany;

namespace Data.Model.ForTermPaper.Invoice
{
    /// <summary>
    /// Случай
    /// </summary>
    [Table(name: "SLCases", Schema = "zap")]
    public class SLCase : BaseGUIDEntity
    {
        [Display(Name = "Идентификатор случая")]
        public string IdCase { get; set; } = string.Empty;
        [Display(Name = "Подразделение МО")]
        public int MedicalCompanyUnitId { get; set; }
        public virtual MedicalCompanyUnit? MedicalCompanyUnit {  get; set; }
        [Display(Name = "Код отделения")]
        public int MedicalCompanyDepartmentId { get; set; }
        public virtual MedicalCompanyDepartment? MedicalCompanyDepartment { get; set; }
        [Display(Name = "Код вида высокотехнологичной медицинской помощи")]
        public int VidVMPId { get; set; }
        //public virtual VidVMP? VidVMP { get; set; }
        [Display(Name = "Код метода высокотехнологичной медицинской помощи")]
        public int VMPMethodId { get; set; }
        //public virtual VMPMethod? VMPMethod { get; set; }
        [Display(Name = "Дата выдачи талона на ВМП")]
        [Column(TypeName = "date")]
        public DateTime TicketReceiveDate { get; set; }
        [Display(Name = "Номер талона на ВМП")]
        [MaxLength(20)]
        public string TicketNumber { get; set; } = string.Empty;
        [Display(Name = "Дата планируемой госпитализации")]
        [Column(TypeName = "date")]
        public DateTime PlannedHospitalizationDate { get; set; }
        [Display(Name = "Id профиля медицинской помощи")]
        public int MedProfileId { get; set; }
        [Display(Name = "Ссылка на объект MedProfile")]
        public virtual MedProfile? MedProfile { get; set; }
        [Display(Name = "Id профиля койки")]
        public int BedMedProfileId { get; set; }
        [Display(Name = "Ссылка на объект BedMedProfile")]
        public virtual BedMedProfile? BedMedProfile { get; set; }
        [Display(Name = "Признак детского профиля")]
        public bool IsChildrenProfile { get; set; }
        [Display(Name = "Id цели посещения")]
        public int VisitPurposeId { get; set; }
        [Display(Name = "Ссылка на объект VisitPurpose")]
        public virtual VisitPurpose? VisitPurpose { get; set; }
        [MaxLength(50)]
        [Display(Name = "Номер истории болезни")]
        public string NumberHistory { get; set; } = string.Empty;
        [Display(Name = "Признак поступления/перевода")]
        public int TransferSign { get; set; }   
        [Display(Name = "Дата начала лечения")]
        [Column(TypeName = "date")]
        public DateTime StartTreatmentDate { get; set; }
        [Display(Name = "Дата окончания лечения")]
        [Column(TypeName = "date")]
        public DateTime EndTreatmentDate { get; set; }
        [Display(Name = "Продолжительность госпитализации")]
        public int DurationHospitalization { get; set; } 
        [Display(Name = "Id характера основного заболевания")]
        public int CharacterDiseaseId { get; set; }
        [Display(Name = "Ссылка на объект CharacterDisease")]
        public virtual CharacterDisease? CharacterDisease { get; set; }
        [Display(Name = "Признак подозрения на злокачественное новообразование")]
        public bool IsCancer { get; set; }
        [Display(Name = "Диспансерное наблюдение")]
        public int DispensaryObservation {  get; set; }
        [Display(Name = "Код стандарта медицинской помощи")]
        [MaxLength(20)]
        public string MedicalCareStandard {  get; set; } = string.Empty;
        [Display(Name = "Код стандарта медицинской помощи сопутствующего заболевания")]
        [MaxLength(20)]
        public string ConcomitantMedicalCareStandard { get; set; } = string.Empty;
        [Display(Name = "Признак реабилитации")]
        public bool IsRehabilitation {  get; set; }
        [Display(Name = "Id специальности лечащего врача")]
        public int DoctorSpecialtyId { get; set; } 
        [Display(Name = "Ссылка на объект MedSpecial")]
        public virtual MedSpecial? DoctorSpecialty { get; set; }
        [Display(Name = "Код классификатора медицинский специальностей")]
        [MaxLength(4)]
        public string MedSpecialVersion { get; set; } = string.Empty;
        [Display(Name = "Код лечащего врача")]
        [MaxLength(25)]
        public string DoctorId { get; set; } = string.Empty;
        [Display(Name = "Количество единиц оплаты медицинской помощи")]
        public decimal PayUnits {  get; set; }
        [Display(Name = "Тариф")]
        public decimal Rate { get; set; }
        [Display(Name = "Выставленная сумма")]
        public decimal TotalSum { get; set; }
        [Display(Name = "Служебное поле")]
        [MaxLength(250)]
        public string Comments { get; set; } = string.Empty;
        [Display(Name = "Масса тела(кг)")]
        public decimal Weight { get; set; }
        [Display(Name = "Id главной записи")]
        public Guid ZapMainRecordId { get; set; }
        [Display(Name = "Ссылка на объект ZAPMainRecord")]
        public virtual ZAPMainRecord? ZapMainRecord { get; set; }
        public virtual List<Diagnosis>? Diagnoses { get; set; }
        public virtual List<Sanction>? Sanctions { get; set; }
        public virtual List<Сoncilium>? Сonciliums { get; set; }

    }
}
