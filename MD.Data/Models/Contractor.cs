namespace MD.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class Contractor
    {
        public Guid Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Полное наименование")]
        public string FullName { get; set; }

        [Display(Name = "Код ИНН")]
        public string INN { get; set; }

        [Display(Name = "Код ОКПО")]
        public string OKPO { get; set; }

        [Display(Name = "Номер свидетельства")]
        public string VATCertificateNumber { get; set; }

        [Display(Name = "Юридический адрес")]
        public string LegalAddress { get; set; }


        public virtual List<Link> Links { get; set; }

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
