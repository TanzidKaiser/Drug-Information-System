namespace Drug_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DoctorPrescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientId = c.String(nullable: false),
                        PatientName = c.String(nullable: false),
                        PatientAge = c.String(nullable: false),
                        VisitedDate = c.DateTime(nullable: false),
                        PatientEmail = c.String(),
                        DoctorId = c.Int(),
                        GenderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId)
                .ForeignKey("dbo.Users", t => t.DoctorId)
                .Index(t => t.DoctorId)
                .Index(t => t.GenderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorPrescriptions", "DoctorId", "dbo.Users");
            DropForeignKey("dbo.DoctorPrescriptions", "GenderId", "dbo.Genders");
            DropIndex("dbo.DoctorPrescriptions", new[] { "GenderId" });
            DropIndex("dbo.DoctorPrescriptions", new[] { "DoctorId" });
            DropTable("dbo.DoctorPrescriptions");
        }
    }
}
