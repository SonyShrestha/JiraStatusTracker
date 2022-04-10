namespace JiraProgressTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueTicketNumber : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Tickets", "TicketNumber", unique: true, name: "TicketNumber");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tickets", "TicketNumber");
        }
    }
}
