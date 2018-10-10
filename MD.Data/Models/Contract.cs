namespace MD.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContractSet")]
    public partial class Contract
    {
        public Guid Id { get; set; }

        [Required]
        public string Number { get; set; }
    }
}
