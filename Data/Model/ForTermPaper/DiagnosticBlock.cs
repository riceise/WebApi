using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model.ForTermPaper
{
    /// <summary>
    /// Диагностический блок
    /// </summary>
    [Table(name: "DiagnosticBlocks", Schema = "zap")]
    public class DiagnosticBlock 
    {
        [Display(Name = "Дата взятия материала")]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        [Display(Name = "Тип диагностического показателя")]
        public int DiagnosticIndicatorType { get; set; }
        [Display(Name = "Id гистологического признака")]
        public int HistologicalFeatureId { get; set; }
        //public virtual HistologicalFeature? HistologicalFeature { get; set; }
        [Display(Name = "Id маркёра")]
        public int CancerMarkerId { get; set; }
        //public virtual CancerMarker? CancerMarker { get; set; }
        [Display(Name = "Id результата гистологического исследования")]
        public int HistologicalExaminationResultId { get; set; }
        //public virtual HistologicalExaminationResult? HistologicalExaminationResult { get; set; }
        [Display(Name = "Id значения маркёра")]
        public int CancerMarkerValueId { get; set; }
        //public virtual CancerMarkerValue? CancerMarkerValue { get; set; }
        [Display(Name = "Признак получения результата диагностики")]
        public bool IsResultReceive {  get; set; }

        [Display(Name = "Id онкологического случая")]
        public Guid CancerCaseId { get; set; }
        //public virtual CancerCase? CancerCase { get; set; }
    }
}