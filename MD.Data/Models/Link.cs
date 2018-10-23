using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MD.Data.Models
{
    public class Link
    {
        public Guid Id { get; set; }

        [Display(Name = "Дата добавления/изменения")]
        public DateTime Date { get; set; }

        [Display(Name = "Контрагент")]
        public Guid ContractorId { get; set; }

        [Display(Name = "Узел")]
        public Guid NodeId { get; set; }

        [Display(Name = "Id в базе узла")]
        public string NativeId { get; set; }


        public virtual Node Node { get; set; }
        public virtual Contractor Contractor { get; set; }

        public static bool Exists(Guid NodeId, string NativeId)
        {
            MdContext db = new MdContext();
            return db.LinkSet.Where(a => a.NativeId == NativeId && a.NodeId == NodeId).Any();
        }
    }
}
