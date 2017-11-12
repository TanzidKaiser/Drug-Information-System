namespace Drug_Information_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrescribedDrugs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrugName = c.String(),
                        DosageForm = c.String(),
                        DosageDuration = c.String(),
                        ExtraNote = c.String(),
                        DoctorPrescriptionId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DoctorPrescriptions", t => t.DoctorPrescriptionId)
                .Index(t => t.DoctorPrescriptionId);
            
            AddColumn("dbo.DoctorPrescriptions", "DoctorSuggestions", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrescribedDrugs", "DoctorPrescriptionId", "dbo.DoctorPrescriptions");
            DropIndex("dbo.PrescribedDrugs", new[] { "DoctorPrescriptionId" });
            DropColumn("dbo.DoctorPrescriptions", "DoctorSuggestions");
            DropTable("dbo.PrescribedDrugs");
        }
    }
}
