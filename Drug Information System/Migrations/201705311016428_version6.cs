namespace Drug_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "UserRole", c => c.String(nullable: false));
            AddColumn("dbo.Users", "UserApproval", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserApproval");
            DropColumn("dbo.Users", "UserRole");
            DropTable("dbo.MessageInfoes");
        }
    }
}
