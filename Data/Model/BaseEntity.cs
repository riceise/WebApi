using System.ComponentModel.DataAnnotations; 
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model
{
    public class BaseEntity
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int? DeletedUserId { get; set; }
    }
}
