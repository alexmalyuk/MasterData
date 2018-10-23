namespace MD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeysDatabaseGenerated_Node : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Nodes", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"));
            AlterColumn("dbo.Links", "Id", c => c.Guid(nullable: false, identity: true, defaultValueSql: "NEWID()"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nodes", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Links", "Id", c => c.Guid(nullable: false));
        }
    }
}
