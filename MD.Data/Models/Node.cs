namespace MD.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public partial class Node
    {
        public Guid Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Активен")]
        public bool IsActive { get; set; }

        [Display(Name = "Алиас")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Допускаются только латинские символы и цифры")]
        public string Alias { get; set; }

        public virtual List<Link> Links { get; set; }

        public override string ToString()
        {
            return Name + (IsActive ? " (Active)" : " (Not active)") ;
        }

        public static Node FindByAlias(string Alias)
        {
            MdContext db = new MdContext();
            return db.NodeSet.Where(a => a.Alias == Alias).FirstOrDefault();
        }
    }
}
