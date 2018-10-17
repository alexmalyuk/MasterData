namespace MD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Links_Alias : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.NodeSet", newName: "Nodes");
            AddColumn("dbo.Nodes", "Alias", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Nodes", "Alias");
            RenameTable(name: "dbo.Nodes", newName: "NodeSet");
        }
    }
}
