namespace WebAppTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameChange : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BookingModels", name: "FacilityID_FacilityID", newName: "Facility_FacilityID");
            RenameColumn(table: "dbo.BookingModels", name: "PetID_PetID", newName: "Pet_PetID");
            RenameColumn(table: "dbo.PetModels", name: "OwnerID_OwnerID", newName: "Owner_OwnerID");
            RenameColumn(table: "dbo.EmployeeModels", name: "FacilityID_FacilityID", newName: "Facility_FacilityID");
            RenameIndex(table: "dbo.BookingModels", name: "IX_FacilityID_FacilityID", newName: "IX_Facility_FacilityID");
            RenameIndex(table: "dbo.BookingModels", name: "IX_PetID_PetID", newName: "IX_Pet_PetID");
            RenameIndex(table: "dbo.EmployeeModels", name: "IX_FacilityID_FacilityID", newName: "IX_Facility_FacilityID");
            RenameIndex(table: "dbo.PetModels", name: "IX_OwnerID_OwnerID", newName: "IX_Owner_OwnerID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PetModels", name: "IX_Owner_OwnerID", newName: "IX_OwnerID_OwnerID");
            RenameIndex(table: "dbo.EmployeeModels", name: "IX_Facility_FacilityID", newName: "IX_FacilityID_FacilityID");
            RenameIndex(table: "dbo.BookingModels", name: "IX_Pet_PetID", newName: "IX_PetID_PetID");
            RenameIndex(table: "dbo.BookingModels", name: "IX_Facility_FacilityID", newName: "IX_FacilityID_FacilityID");
            RenameColumn(table: "dbo.EmployeeModels", name: "Facility_FacilityID", newName: "FacilityID_FacilityID");
            RenameColumn(table: "dbo.PetModels", name: "Owner_OwnerID", newName: "OwnerID_OwnerID");
            RenameColumn(table: "dbo.BookingModels", name: "Pet_PetID", newName: "PetID_PetID");
            RenameColumn(table: "dbo.BookingModels", name: "Facility_FacilityID", newName: "FacilityID_FacilityID");
        }
    }
}
