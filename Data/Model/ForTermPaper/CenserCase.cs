using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// using Data.Model.Entities.Common;
// using Data.Model.Entities.Dictionary;

namespace Data.Model.Entities.Invoice
{
    /// <summary>
    /// Сведения о случае лечения онкологического заболевания
    /// </summary>
    [Table(name: "CancerCases", Schema = "zap")]
    public class CancerCase 
    {
        [Display(Name = "Id повода обращения")]
        public int ReasonAppealId { get; set; }
        
        [Display(Name = "Id стадии заболевания")]
        public int StageId { get; set; }
        
        [Display(Name = "Id значения Tumor")]
        public int TumorId { get; set; }
        
        [Display(Name = "Id значения Nodus")]
        public int NodusId { get; set; }
        
        [Display(Name = "Id случая")]
        public Guid SLCaseId { get; set; }
    }
}
