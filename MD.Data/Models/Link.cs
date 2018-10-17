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
        private MdContext db = new MdContext();

        public Guid Id { get; set; }

        [Display(Name = "Дата добавления")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Контрагент Id")]
        public Guid ContractorId { get; set; }

        [Display(Name = "Контрагент")]
        public Contractor Contractor
        {
            get
            {
                var query = db.ContractorSet.Where(c => c.Id == ContractorId).FirstOrDefault();
                return query;
            }
            set { }
        }

        [Required]
        [Display(Name = "Id в базе узла")]
        public string NativeId { get; set; }

        [Required]
        [Display(Name = "Узел Id")]
        public Guid NodeId { get; set; }

        [Display(Name = "Узел")]
        public Node Node
        {
            get
            {
                var query = db.NodeSet.Where(c => c.Id == NodeId).FirstOrDefault();
                return query;
            }
    set { }
        }
    }
}
