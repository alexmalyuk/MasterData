namespace MD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cascade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Links", "ContractorId", "dbo.Contractors");
            AddForeignKey("dbo.Links", "ContractorId", "dbo.Contractors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "ContractorId", "dbo.Contractors");
            AddForeignKey("dbo.Links", "ContractorId", "dbo.Contractors", "Id", cascadeDelete: true);
        }
    }
}
