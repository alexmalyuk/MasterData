namespace MD.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Table("ContractorSet")]
    public partial class Contractor
    {
        public Guid Id { get; set; }

        [Required, Index, MaxLength(100)]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Полное наименование")]
        public string FullName { get; set; }

        [Required, Index, MaxLength(12)]
        [Display(Name = "Код ИНН")]
        public string INN { get; set; }

        [Index, MaxLength(10)]
        [Display(Name = "Код ОКПО")]
        public string OKPO { get; set; }

        [Index, MaxLength(10)]
        [Display(Name = "Номер свидетельства")]
        public string VATCertificateNumber { get; set; }

        [Display(Name = "Юридический адрес")]
        public string LegalAddress { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public static Contractor FindByINN(string INN)
        {
            MdContext db = new MdContext();
            return db.ContractorSet.Where(a => a.INN == INN).FirstOrDefault();
        }
    }
}
