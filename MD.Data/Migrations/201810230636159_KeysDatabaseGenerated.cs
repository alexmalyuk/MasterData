namespace MD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeysDatabaseGenerated : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ContractSet");
            AlterColumn("dbo.ContractSet", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"));
            AlterColumn("dbo.Nodes", "Name", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.ContractSet", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ContractSet");
            AlterColumn("dbo.Nodes", "Name", c => c.String());
            AlterColumn("dbo.ContractSet", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.ContractSet", "Id");
        }
    }
}
