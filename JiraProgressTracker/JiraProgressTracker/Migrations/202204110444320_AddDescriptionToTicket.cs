namespace JiraProgressTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionToTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "Description");
        }
    }
}
