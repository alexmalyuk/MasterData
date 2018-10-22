namespace MD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseGeneratedIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Links", "ContractorId", "dbo.ContractorSet");
            DropIndex("dbo.ContractorSet", new[] { "INN" });
            DropPrimaryKey("dbo.ContractorSet");
            DropPrimaryKey("dbo.Links");
            AlterColumn("dbo.ContractorSet", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"));
            AlterColumn("dbo.ContractorSet", "INN", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.Links", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.ContractorSet", "Id");
            AddPrimaryKey("dbo.Links", "Id");
            CreateIndex("dbo.ContractorSet", "INN");
            AddForeignKey("dbo.Links", "ContractorId", "dbo.ContractorSet", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "ContractorId", "dbo.ContractorSet");
            DropIndex("dbo.ContractorSet", new[] { "INN" });
            DropPrimaryKey("dbo.Links");
            DropPrimaryKey("dbo.ContractorSet");
            AlterColumn("dbo.Links", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.ContractorSet", "INN", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.ContractorSet", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Links", "Id");
            AddPrimaryKey("dbo.ContractorSet", "Id");
            CreateIndex("dbo.ContractorSet", "INN");
            AddForeignKey("dbo.Links", "ContractorId", "dbo.ContractorSet", "Id", cascadeDelete: true);
        }
    }
}
