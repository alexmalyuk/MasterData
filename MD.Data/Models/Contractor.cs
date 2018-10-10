namespace MD.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContractorSet")]
    public partial class Contractor
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
