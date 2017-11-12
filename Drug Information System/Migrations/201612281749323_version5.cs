namespace Drug_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DoctorPrescriptions", "VisitedDate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DoctorPrescriptions", "VisitedDate", c => c.DateTime(nullable: false));
        }
    }
}
