namespace JiraProgressTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketNumberAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "TicketNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "TicketNumber");
        }
    }
}
