namespace MD.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    //[Table("NodeSet")]
    public partial class Node
    {
        [Display(Name = "Идентификатор")]
        public Guid Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Активен")]
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Алиас")]
        [Range(3, 5)]
        public string Alias { get; set; }

        public override string ToString()
        {
            return Name + (IsActive ? " (Active)" : " (Not active)") ;
        }
    }
}
