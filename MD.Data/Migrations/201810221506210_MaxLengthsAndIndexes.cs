namespace MD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaxLengthsAndIndexes : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Links", new[] { "ContractorId" });
            DropIndex("dbo.Links", new[] { "NodeId" });
            AddColumn("dbo.ContractorSet", "VATCertificateNumber", c => c.String(maxLength: 10));
            AlterColumn("dbo.ContractorSet", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ContractorSet", "INN", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.ContractorSet", "OKPO", c => c.String(maxLength: 10));
            AlterColumn("dbo.Links", "NativeId", c => c.String(nullable: false, maxLength: 36));
            CreateIndex("dbo.ContractorSet", "Name");
            CreateIndex("dbo.ContractorSet", "INN");
            CreateIndex("dbo.ContractorSet", "OKPO");
            CreateIndex("dbo.ContractorSet", "VATCertificateNumber");
            CreateIndex("dbo.Links", "ContractorId");
            CreateIndex("dbo.Links", "NativeId");
            CreateIndex("dbo.Links", "NodeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Links", new[] { "NodeId" });
            DropIndex("dbo.Links", new[] { "NativeId" });
            DropIndex("dbo.Links", new[] { "ContractorId" });
            DropIndex("dbo.ContractorSet", new[] { "VATCertificateNumber" });
            DropIndex("dbo.ContractorSet", new[] { "OKPO" });
            DropIndex("dbo.ContractorSet", new[] { "INN" });
            DropIndex("dbo.ContractorSet", new[] { "Name" });
            AlterColumn("dbo.Links", "NativeId", c => c.String(nullable: false));
            AlterColumn("dbo.ContractorSet", "OKPO", c => c.String());
            AlterColumn("dbo.ContractorSet", "INN", c => c.String(nullable: false));
            AlterColumn("dbo.ContractorSet", "Name", c => c.String(nullable: false));
            DropColumn("dbo.ContractorSet", "VATCertificateNumber");
            CreateIndex("dbo.Links", "NodeId");
            CreateIndex("dbo.Links", "ContractorId");
        }
    }
}
