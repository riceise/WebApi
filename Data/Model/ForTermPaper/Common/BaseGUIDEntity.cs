using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model.ForTermPaper.Common
{
    public class BaseGUIDEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EditDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }

        public BaseGUIDEntity()
        {
            CreateDate = DateTime.Today;
            EditDate = DateTime.Today;
            DeleteDate = DateTime.MaxValue;
            IsDeleted = false;
        }
    }
}