namespace Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmergencyCall",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Address = c.String(),
                        LevelOfUrgency = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        AssignationDate = c.DateTime(nullable: false),
                        SolvedDate = c.DateTime(nullable: false),
                        Solved = c.Boolean(nullable: false),
                        AssignMode = c.Int(nullable: false),
                        Location_Id = c.Int(),
                        Mobile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Location", t => t.Location_Id)
                .ForeignKey("dbo.MobileUnit", t => t.Mobile_Id)
                .Index(t => t.Location_Id)
                .Index(t => t.Mobile_Id);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MobileUnit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Plate = c.String(),
                        Description = c.String(),
                        Available = c.Boolean(nullable: false),
                        Location_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Location", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmergencyCall", "Mobile_Id", "dbo.MobileUnit");
            DropForeignKey("dbo.MobileUnit", "Location_Id", "dbo.Location");
            DropForeignKey("dbo.EmergencyCall", "Location_Id", "dbo.Location");
            DropIndex("dbo.MobileUnit", new[] { "Location_Id" });
            DropIndex("dbo.EmergencyCall", new[] { "Mobile_Id" });
            DropIndex("dbo.EmergencyCall", new[] { "Location_Id" });
            DropTable("dbo.MobileUnit");
            DropTable("dbo.Location");
            DropTable("dbo.EmergencyCall");
        }
    }
}
