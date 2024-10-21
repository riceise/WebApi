namespace Share.DTOs
{
    public class CreateDictionaryRequestDto
    {
        //public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        
    }  
}
