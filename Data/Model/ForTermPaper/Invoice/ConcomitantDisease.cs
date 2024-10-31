using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Model.ForTermPaper.Common;

namespace Data.Model.ForTermPaper.Invoice
{
    /// <summary>
    /// Сопутствующие заболевания (DS2_N)
    /// </summary>
    [Table(name: "ConcomitantDiseases", Schema = "zap")]
    public class ConcomitantDisease : BaseGUIDEntity
    {
        [Display(Name = "Id диагноза")]
        public int DiagnosisId { get; set; }
        //public virtual Diagnosis? Diagnosis { get; set; }
        [Display(Name = "Установлен впервые (сопутствующий)")]
        public bool IsFirstInstalled { get; set; }
        [Display(Name = "Диспансерное наблюдение")]
        public int DispensaryObservation { get; set; }
        [Display(Name = "Id случая")]
        public Guid SLCaseId { get; set; }
        //public virtual SLCase? SLCase { get; set; }
    }
}