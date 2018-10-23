namespace MD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FluentAPI : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ContractorSet", newName: "Contractors");
            DropForeignKey("dbo.Links", "NodeId", "dbo.Nodes");
            AlterColumn("dbo.Links", "Date", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Nodes", "Name", unique: true);
            CreateIndex("dbo.Nodes", "Alias", unique: true);
            AddForeignKey("dbo.Links", "NodeId", "dbo.Nodes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "NodeId", "dbo.Nodes");
            DropIndex("dbo.Nodes", new[] { "Alias" });
            DropIndex("dbo.Nodes", new[] { "Name" });
            AlterColumn("dbo.Links", "Date", c => c.DateTime(nullable: false));
            AddForeignKey("dbo.Links", "NodeId", "dbo.Nodes", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Contractors", newName: "ContractorSet");
        }
    }
}
