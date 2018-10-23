using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MD.Data.Models
{
    public class Link
    {
        //private MdContext db = new MdContext();

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Дата добавления/изменения")]
        public DateTime Date { get; set; }

        [Required, Index]
        [Display(Name = "Контрагент")]
        public Guid ContractorId { get; set; }

        [Required, Index]
        [Display(Name = "Узел")]
        public Guid NodeId { get; set; }

        [Required, Index, MaxLength(36)]
        [Display(Name = "Id в базе узла")]
        public string NativeId { get; set; }


        public Node Node { get; set; }
        public Contractor Contractor { get; set; }

        public static bool Exists(Guid NodeId, string NativeId)
        {
            MdContext db = new MdContext();
            return db.LinkSet.Where(a => a.NativeId == NativeId && a.NodeId == NodeId).Any();
        }
    }
}
