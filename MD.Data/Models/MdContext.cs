namespace MD.Data.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MdContext : DbContext
    {
        public MdContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Contractor> ContractorSet { get; set; }
        public virtual DbSet<Contract> ContractSet { get; set; }
        public virtual DbSet<Node> NodeSet { get; set; }
        public virtual DbSet<Link> LinkSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
