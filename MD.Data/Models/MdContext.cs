namespace MD.Data.Models
{
    using Configuration;
    using System.Data.Entity;

    public partial class MdContext : DbContext
    {
        public MdContext() : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Contractor> Contractors { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
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
