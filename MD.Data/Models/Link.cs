using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        public Contractor Contractor { get; set; }

        [Required]
        [Display(Name = "Id в базе узла")]
        public string NativeId { get; set; }

        [Required]
        [Display(Name = "Узел Id")]
        public Guid NodeId { get; set; }

        [Display(Name = "Узел")]
        public Node Node { get; set; }

        public static bool Exists(Guid NodeId, string NativeId)
        {
            MdContext db = new MdContext();
            return db.LinkSet.Where(a => a.NativeId == NativeId && a.NodeId == NodeId).Any();
        }
    }
}
