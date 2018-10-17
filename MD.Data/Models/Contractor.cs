namespace MD.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ContractorSet")]
    public partial class Contractor
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Полное наименование")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Код ИНН")]
        public string INN { get; set; }

        [Display(Name = "Код ОКПО")]
        public string OKPO { get; set; }

        [Display(Name = "Юридический адрес")]
        public string LegalAddress { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
