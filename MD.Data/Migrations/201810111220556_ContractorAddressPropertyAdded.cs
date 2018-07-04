namespace MD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContractorAddressPropertyAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContractorSet", "FullName", c => c.String());
            AddColumn("dbo.ContractorSet", "LegalAddress", c => c.String());
            AlterColumn("dbo.ContractorSet", "INN", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContractorSet", "INN", c => c.String());
            DropColumn("dbo.ContractorSet", "LegalAddress");
            DropColumn("dbo.ContractorSet", "FullName");
        }
    }
}
