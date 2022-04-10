namespace JiraProgressTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "PriorityId", c => c.Int(nullable: false,defaultValue:1));
            AddColumn("dbo.Tickets", "TicketTypeId", c => c.Int(nullable: false, defaultValue: 1));
            CreateIndex("dbo.Tickets", "PriorityId");
            CreateIndex("dbo.Tickets", "TicketTypeId");
            AddForeignKey("dbo.Tickets", "PriorityId", "dbo.Priorities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "TicketTypeId", "dbo.TicketTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TicketTypeId", "dbo.TicketTypes");
            DropForeignKey("dbo.Tickets", "PriorityId", "dbo.Priorities");
            DropIndex("dbo.Tickets", new[] { "TicketTypeId" });
            DropIndex("dbo.Tickets", new[] { "PriorityId" });
            DropColumn("dbo.Tickets", "TicketTypeId");
            DropColumn("dbo.Tickets", "PriorityId");
        }
    }
}
