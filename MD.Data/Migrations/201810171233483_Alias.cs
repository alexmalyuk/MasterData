namespace MD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Alias : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Nodes", "Alias", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nodes", "Alias", c => c.String(nullable: false));
        }
    }
}
