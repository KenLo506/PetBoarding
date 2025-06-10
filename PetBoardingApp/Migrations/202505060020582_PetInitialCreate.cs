namespace PetBoardingApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PetInitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingModels",
                c => new
                    {
                        BookingID = c.Guid(nullable: false),
                        PetInstructions = c.String(),
                        BookingStartTime = c.DateTime(nullable: false),
                        BookingEndTime = c.DateTime(nullable: false),
                        ActualCheckInTime = c.DateTime(),
                        ActualCheckOutTime = c.DateTime(),
                        Status = c.Int(nullable: false),
                        FeedingSchedule = c.String(),
                        FoodAmount = c.String(),
                        FacilityID_FacilityID = c.Guid(),
                        CheckedOutByEmployeeID_EmployeeID = c.Guid(),
                        CheckInByEmployeeID_EmployeeID = c.Guid(),
                        PetID_PetID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.FacilityModels", t => t.FacilityID_FacilityID)
                .ForeignKey("dbo.EmployeeModels", t => t.CheckedOutByEmployeeID_EmployeeID)
                .ForeignKey("dbo.EmployeeModels", t => t.CheckInByEmployeeID_EmployeeID)
                .ForeignKey("dbo.PetModels", t => t.PetID_PetID, cascadeDelete: true)
                .Index(t => t.FacilityID_FacilityID)
                .Index(t => t.CheckedOutByEmployeeID_EmployeeID)
                .Index(t => t.CheckInByEmployeeID_EmployeeID)
                .Index(t => t.PetID_PetID);
            
            CreateTable(
                "dbo.EmployeeModels",
                c => new
                    {
                        EmployeeID = c.Guid(nullable: false),
                        FullName = c.String(nullable: false),
                        Role = c.String(),
                        ShiftCheckIn = c.DateTime(nullable: false),
                        ShiftCheckOut = c.DateTime(nullable: false),
                        FacilityID_FacilityID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.FacilityModels", t => t.FacilityID_FacilityID, cascadeDelete: true)
                .Index(t => t.FacilityID_FacilityID);
            
            CreateTable(
                "dbo.FacilityModels",
                c => new
                    {
                        FacilityID = c.Guid(nullable: false),
                        FacilityName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 100),
                        MaxOccupancy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FacilityID);
            
            CreateTable(
                "dbo.PetModels",
                c => new
                    {
                        PetID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Breed = c.String(),
                        Age = c.Int(nullable: false),
                        Vaccines = c.String(),
                        Medications = c.String(),
                        ExtraNotes = c.String(),
                        OwnerID_OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PetID)
                .ForeignKey("dbo.PetOwnerModels", t => t.OwnerID_OwnerID, cascadeDelete: true)
                .Index(t => t.OwnerID_OwnerID);
            
            CreateTable(
                "dbo.PetOwnerModels",
                c => new
                    {
                        OwnerID = c.Guid(nullable: false),
                        FullName = c.String(nullable: false),
                        Email = c.String(maxLength: 1000),
                        Phone = c.String(maxLength: 10),
                        EmergencyContact = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.OwnerID);
            
            DropTable("dbo.ToDoModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ToDoModels",
                c => new
                    {
                        ToDoID = c.Guid(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(maxLength: 1000),
                        IsComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ToDoID);
            
            DropForeignKey("dbo.BookingModels", "PetID_PetID", "dbo.PetModels");
            DropForeignKey("dbo.PetModels", "OwnerID_OwnerID", "dbo.PetOwnerModels");
            DropForeignKey("dbo.BookingModels", "CheckInByEmployeeID_EmployeeID", "dbo.EmployeeModels");
            DropForeignKey("dbo.BookingModels", "CheckedOutByEmployeeID_EmployeeID", "dbo.EmployeeModels");
            DropForeignKey("dbo.EmployeeModels", "FacilityID_FacilityID", "dbo.FacilityModels");
            DropForeignKey("dbo.BookingModels", "FacilityID_FacilityID", "dbo.FacilityModels");
            DropIndex("dbo.PetModels", new[] { "OwnerID_OwnerID" });
            DropIndex("dbo.EmployeeModels", new[] { "FacilityID_FacilityID" });
            DropIndex("dbo.BookingModels", new[] { "PetID_PetID" });
            DropIndex("dbo.BookingModels", new[] { "CheckInByEmployeeID_EmployeeID" });
            DropIndex("dbo.BookingModels", new[] { "CheckedOutByEmployeeID_EmployeeID" });
            DropIndex("dbo.BookingModels", new[] { "FacilityID_FacilityID" });
            DropTable("dbo.PetOwnerModels");
            DropTable("dbo.PetModels");
            DropTable("dbo.FacilityModels");
            DropTable("dbo.EmployeeModels");
            DropTable("dbo.BookingModels");
        }
    }
}
