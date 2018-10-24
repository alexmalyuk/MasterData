namespace MD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contractors",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        FullName = c.String(),
                        INN = c.String(nullable: false, maxLength: 12),
                        OKPO = c.String(maxLength: 10),
                        VATCertificateNumber = c.String(maxLength: 10),
                        LegalAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name)
                .Index(t => t.INN)
                .Index(t => t.OKPO)
                .Index(t => t.VATCertificateNumber);
            
            CreateTable(
                "dbo.Links",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ContractorId = c.Guid(nullable: false),
                        NodeId = c.Guid(nullable: false),
                        NativeId = c.String(nullable: false, maxLength: 36),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contractors", t => t.ContractorId)
                .ForeignKey("dbo.Nodes", t => t.NodeId)
                .Index(t => t.ContractorId)
                .Index(t => t.NodeId)
                .Index(t => t.NativeId);
            
            CreateTable(
                "dbo.Nodes",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        Alias = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.Alias, unique: true);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Number = c.String(nullable: false, maxLength: 30),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Number);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Links", "NodeId", "dbo.Nodes");
            DropForeignKey("dbo.Links", "ContractorId", "dbo.Contractors");
            DropIndex("dbo.Contracts", new[] { "Number" });
            DropIndex("dbo.Nodes", new[] { "Alias" });
            DropIndex("dbo.Nodes", new[] { "Name" });
            DropIndex("dbo.Links", new[] { "NativeId" });
            DropIndex("dbo.Links", new[] { "NodeId" });
            DropIndex("dbo.Links", new[] { "ContractorId" });
            DropIndex("dbo.Contractors", new[] { "VATCertificateNumber" });
            DropIndex("dbo.Contractors", new[] { "OKPO" });
            DropIndex("dbo.Contractors", new[] { "INN" });
            DropIndex("dbo.Contractors", new[] { "Name" });
            DropTable("dbo.Contracts");
            DropTable("dbo.Nodes");
            DropTable("dbo.Links");
            DropTable("dbo.Contractors");
        }
    }
}
