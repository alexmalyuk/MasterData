namespace MD.Data.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Configuration;

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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new NodeConfig());
            modelBuilder.Configurations.Add(new ContractorConfig());
            modelBuilder.Configurations.Add(new LinkConfig());
        }

    }
}
