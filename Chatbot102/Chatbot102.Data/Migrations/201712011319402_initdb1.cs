namespace Chatbot102.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeaveApplications",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        LeaveType = c.String(),
                        LeaveFrom = c.DateTime(nullable: false),
                        LeaveTo = c.DateTime(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LeaveApplications");
        }
    }
}
