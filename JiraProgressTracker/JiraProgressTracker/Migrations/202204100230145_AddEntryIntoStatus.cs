namespace JiraProgressTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntryIntoStatus : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Status(Name) values('To Do')");
            Sql("Insert into Status(Name) values('In Progress')");
            Sql("Insert into Status(Name) values('QA Review')");
            Sql("Insert into Status(Name) values('Business Validation')");
            Sql("Insert into Status(Name) values('Done')");
        }
        
        public override void Down()
        {
        }
    }
}
