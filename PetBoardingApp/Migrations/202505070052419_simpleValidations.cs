namespace PetBoardingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class simpleValidations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookingModels", "Facility_FacilityID", "dbo.FacilityModels");
            DropIndex("dbo.BookingModels", new[] { "Facility_FacilityID" });
            AlterColumn("dbo.BookingModels", "PetInstructions", c => c.String(maxLength: 1000));
            AlterColumn("dbo.BookingModels", "FeedingSchedule", c => c.String(maxLength: 100));
            AlterColumn("dbo.BookingModels", "FoodAmount", c => c.String(maxLength: 100));
            AlterColumn("dbo.BookingModels", "Facility_FacilityID", c => c.Guid(nullable: false));
            AlterColumn("dbo.EmployeeModels", "FullName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.EmployeeModels", "Role", c => c.String(maxLength: 50));
            AlterColumn("dbo.PetModels", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.PetModels", "Breed", c => c.String(maxLength: 50));
            AlterColumn("dbo.PetModels", "Vaccines", c => c.String(maxLength: 100));
            AlterColumn("dbo.PetModels", "Medications", c => c.String(maxLength: 100));
            AlterColumn("dbo.PetModels", "ExtraNotes", c => c.String(maxLength: 500));
            CreateIndex("dbo.BookingModels", "Facility_FacilityID");
            AddForeignKey("dbo.BookingModels", "Facility_FacilityID", "dbo.FacilityModels", "FacilityID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingModels", "Facility_FacilityID", "dbo.FacilityModels");
            DropIndex("dbo.BookingModels", new[] { "Facility_FacilityID" });
            AlterColumn("dbo.PetModels", "ExtraNotes", c => c.String());
            AlterColumn("dbo.PetModels", "Medications", c => c.String());
            AlterColumn("dbo.PetModels", "Vaccines", c => c.String());
            AlterColumn("dbo.PetModels", "Breed", c => c.String());
            AlterColumn("dbo.PetModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.EmployeeModels", "Role", c => c.String());
            AlterColumn("dbo.EmployeeModels", "FullName", c => c.String(nullable: false));
            AlterColumn("dbo.BookingModels", "Facility_FacilityID", c => c.Guid());
            AlterColumn("dbo.BookingModels", "FoodAmount", c => c.String());
            AlterColumn("dbo.BookingModels", "FeedingSchedule", c => c.String());
            AlterColumn("dbo.BookingModels", "PetInstructions", c => c.String());
            CreateIndex("dbo.BookingModels", "Facility_FacilityID");
            AddForeignKey("dbo.BookingModels", "Facility_FacilityID", "dbo.FacilityModels", "FacilityID");
        }
    }
}
