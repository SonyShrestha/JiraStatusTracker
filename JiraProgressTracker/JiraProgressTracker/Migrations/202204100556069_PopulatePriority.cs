namespace JiraProgressTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatePriority : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Priorities(Name) values('Low')");
            Sql("Insert into Priorities(Name) values('Medium')");
            Sql("Insert into Priorities(Name) values('High')");
        }
        
        public override void Down()
        {
        }
    }
}
