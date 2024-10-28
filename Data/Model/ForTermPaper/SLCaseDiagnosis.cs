using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// using Data.Model.Entities.Common;
// using Data.Model.Entities.Dictionary;

namespace Data.Model.Entities.Invoice
{
    [Table(name: "SLCaseDiagnoses", Schema = "zap")]
    public class SLCaseDiagnosis 
    {
        [Display(Name = "Id случая")]
        public Guid SLCaseId { get; set; }
        //public virtual SLCase? SLCase { get; set; }
        [Display(Name = "Тип диагноза")]
        public int DiagnosisType { get; set; }
        [Display(Name = "Id диагноза")]
        public int DiagnosisId { get; set; }
        //public virtual Diagnosis? Diagnosis { get; set; }

        [Display(Name = "Установлен впервые (основной)")]
        public bool IsFirstInstalled { get; set; }

    }
}