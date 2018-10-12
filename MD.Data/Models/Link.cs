using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.Data.Models
{
    public class Link
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Contractor Id")]
        public Guid ContractorId { get; set; }

        [Display(Name = "Contractor")]

        public Contractor Contractor { get; set; }

        [Required]
        [Display(Name = "Native Id")]
        public string NativeId { get; set; }

        [Required]
        [Display(Name = "Node Id")]
        public Guid NodeId { get; set; }

        public Node Node { get; set; }
    }
}
