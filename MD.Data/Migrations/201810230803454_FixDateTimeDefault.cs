namespace MD.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDateTimeDefault : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Links", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Links", "Date", c => c.DateTime(nullable: false));
        }
    }
}
