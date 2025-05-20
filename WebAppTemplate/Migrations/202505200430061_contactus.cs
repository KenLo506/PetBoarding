namespace WebAppTemplate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactUsModels",
                c => new
                    {
                        ContactUsID = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        Email = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        SubmittedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContactUsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactUsModels");
        }
    }
}
