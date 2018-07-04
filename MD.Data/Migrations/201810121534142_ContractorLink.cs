namespace MD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContractorLink : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ContractorId = c.Guid(nullable: false),
                        NativeId = c.String(nullable: false),
                        NodeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContractorSet", t => t.ContractorId, cascadeDelete: true)
                .ForeignKey("dbo.NodeSet", t => t.NodeId, cascadeDelete: true)
                .Index(t => t.ContractorId)
                .Index(t => t.NodeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "NodeId", "dbo.NodeSet");
            DropForeignKey("dbo.Links", "ContractorId", "dbo.ContractorSet");
            DropIndex("dbo.Links", new[] { "NodeId" });
            DropIndex("dbo.Links", new[] { "ContractorId" });
            DropTable("dbo.Links");
        }
    }
}
