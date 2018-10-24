namespace MD.Data.Models
{
    using Common;
    using Configuration;
    using System;
    using System.Data.Entity;

    public partial class MdContext : DbContext
    {
        public MdContext() : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Contractor> Contractors { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Node> Nodes { get; set; }
        public virtual DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new NodeConfig());
            modelBuilder.Configurations.Add(new ContractorConfig());
            modelBuilder.Configurations.Add(new ContractConfig());
            modelBuilder.Configurations.Add(new LinkConfig());
        }

    }
}
