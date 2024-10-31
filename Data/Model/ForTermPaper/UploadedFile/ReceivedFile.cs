using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Model.ForTermPaper.UploadedFile
{
    public class ReceivedFile
    {
        [Display(Name = "№ п/п")]
        public int Npp { get; set; }

        [MaxLength(100)]
        [Display(Name = "Фамилия")]
        public string Fam { get; set; } = string.Empty;

        [MaxLength(100)]
        [Display(Name = "Имя")]
        public string Im { get; set; } = string.Empty;

        [MaxLength(100)]
        [Display(Name = "Отчество")]
        public string Ot { get; set; } = string.Empty;

        [Column(TypeName = "date")]
        [Display(Name = "Дата рождения")]
        public DateTime Dr { get; set; }

        [MaxLength(14)]
        [Display(Name = "СНИЛС")]
        public string Snils { get; set; } = string.Empty;

        [Display(Name = "№ Реестра")]
        public int NReestr { get; set; }

        [Display(Name = "Период")]
        public int Period { get; set; }

        [MaxLength(200)]
        [Display(Name = "Организация")]
        public string Organizaciya { get; set; } = string.Empty;
    }
}
