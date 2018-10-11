namespace MD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class INN_OKPO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContractorSet", "INN", c => c.String());
            AddColumn("dbo.ContractorSet", "OKPO", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContractorSet", "OKPO");
            DropColumn("dbo.ContractorSet", "INN");
        }
    }
}
