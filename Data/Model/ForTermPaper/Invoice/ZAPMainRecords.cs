using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Model.ForTermPaper.Common;

//using Telerik.SvgIcons;

namespace Data.Model.ForTermPaper.Invoice
{
    [Table(name: "ZAPMainRecords", Schema = "zap")]
    public class ZAPMainRecord : BaseGUIDEntity
    {
        /// <summary>
        /// Номер записи N_ZAP
        /// </summary>
        [Display(Name = "Номер записи")]
        public int Number { get; set; }
        [Display(Name = "Признак исправленной записи")]
        public bool IsEdited { get; set; }
        [Display(Name = "Id пациента")]
        public Guid PersonId { get; set; }
        [Display(Name = "Ссылка на объект Person")]
        public virtual Person.Person? Person { get; set; }
        [Display(Name = "Id полиса")]
        public int PolicyId { get; set; }
        [Display(Name = "Ссылка на объект Policy")]
        public virtual Policy.Policy? Policy { get; set; }
        [Display(Name = "Группа ивалидности")]
        public int InvGroup { get; set; }
        [Display(Name = "Направление на МСЭ")]
        public bool IsMSE { get; set; }
        [MaxLength(9)]
        [Display(Name = "Признак новорожденного")]
        public string NewBorn { get; set; } = string.Empty;
        [Display(Name = "Веc при рождении")]
        public string NewBornWeight { get; set; } = string.Empty;
        [Display(Name = "Id реестра счетов")]
        public int InvoiceId { get; set; }
        [Display(Name = "Ссылка на объект Invoice")]
        public virtual Entities.Invoice.Invoice? Invoice { get; set; }
        //Законченный случай
        [Display(Name = "Номер записи в реестре законченных случаев")]
        public int NumberCase { get; set; }  
        [Display(Name = "Id вида случая")]
        public int VidSluchId { get; set; }
        public virtual VidSluch? VidSluch { get; set; }
        [Display(Name = "Id условия оказания")]
        public int UMPId { get;set; }
        public virtual UMP? UMP { get; set; }
        [Display(Name = "Id вида медицинской помощи")]
        public int VidPomId { get; set; }
        public virtual VidPom? VidPom { get; set; }
        [Display(Name = "Id формы медицинской помощи")]
        public int FormPomId { get; set; }
        public virtual FormPom? FormPom { get; set; }
        [Display(Name = "Id МО направившей на лечение")]
        public int DirectedMOId { get; set; }
        public virtual MedicalCompany.MedicalCompany? DirectedMO { get; set; }
        [Display(Name = "Дата направления на лечение")]
        [Column(TypeName = "date")]
        public DateTime DirectedDate { get; set; }
        [Display(Name = "Id МО")]
        public int MedicalCompanyId { get; set; }
        public virtual MedicalCompany.MedicalCompany? MedicalCompany { get; set; }
        [Display(Name = "Признак мобильной медицинской бригады")]
        public bool IsMobileMedicalTeam { get; set; }  
        [Display(Name = "Признак отказа")]
        public bool IsRefusal { get; set; }
        [Display(Name = "Дата начала лечения")]
        [Column(TypeName = "date")]
        public DateTime StartTreatmentDate { get; set; }
        [Display(Name = "Дата окончания  лечения")]
        [Column(TypeName = "date")]
        public DateTime EndTreatmentDate { get; set; }
        [Display(Name = "Продолжительность госпитализации")]
        public int DurationHospitalization { get; set; }
        [Display(Name = "Id результата обращения")]
        public int ResultId { get; set; }
        public virtual Result? Result { get; set; }
        [Display(Name = "Id результата диспансеризации")]
        public int ResultDispId { get; set; }
        public virtual ResultDisp? ResultDisp { get; set; }
        [Display(Name = "Id исхода заболевания")]
        public int IshodId { get; set; }
        public virtual Ishod? Ishod { get; set; }
        [Display(Name = "Признак особого случая")]
        public string IsSpecialCase { get; set; } = string.Empty;
        [Display(Name = "Признак внутрибольничного перевода")]
        public bool IsIntrahospitalTransfer  { get; set; }
        [Display(Name = "Id способа оплаты медицинской помощи")]
        public int PaymentMethodId { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }
        [Display(Name = "Выставленная сумма")]
        public decimal TotalSum { get; set; }
        [Display(Name = "Тип оплаты")]
        public int Pay { get; set; }
        [Display(Name = "Сумма к оплате")]
        public decimal PaySum { get; set; }
        [Display(Name = "Сумма санкций")]
        public decimal SankSum { get; set; }
        [Display(Name = "Признак оплаты")]
        public bool IsPay { get; set; }
    }
}
