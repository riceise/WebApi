namespace Data.Model
{
    public class DictionaryItem : BaseEntity
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;


    }
}
