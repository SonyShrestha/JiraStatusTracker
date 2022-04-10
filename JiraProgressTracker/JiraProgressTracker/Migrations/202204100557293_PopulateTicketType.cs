namespace JiraProgressTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTicketType : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into TicketTypes(Name) values('Development')");
            Sql("Insert into TicketTypes(Name) values('Bug')");
            Sql("Insert into TicketTypes(Name) values('Spike')");
        }
        
        public override void Down()
        {
        }
    }
}
