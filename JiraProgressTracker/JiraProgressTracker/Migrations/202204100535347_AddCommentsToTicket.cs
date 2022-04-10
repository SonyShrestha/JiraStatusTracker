namespace JiraProgressTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentsToTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Comments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "Comments");
        }
    }
}
