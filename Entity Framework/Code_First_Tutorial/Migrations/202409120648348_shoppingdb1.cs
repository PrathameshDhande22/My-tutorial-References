namespace Code_First_Tutorial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shoppingdb1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "visit.Visitor",
                c => new
                    {
                        Stays = c.String(),
                        VisitorId = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 30),
                        LastName = c.String(),
                        PinCode = c.Int(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VisitorId)
                .ForeignKey("shop.ShopProducts", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "shop.ShopProducts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ShopName = c.String(),
                        ProductName = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "shop.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(),
                    })
                .PrimaryKey(t => t.DoctorId);
            
            CreateTable(
                "shop.Patients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        PatientName = c.String(),
                    })
                .PrimaryKey(t => t.PatientId);
            
            CreateTable(
                "shop.Samples",
                c => new
                    {
                        SampleId = c.Int(nullable: false, identity: true),
                        SampleDiv = c.String(),
                        SampleName = c.String(),
                    })
                .PrimaryKey(t => t.SampleId);
            
            CreateTable(
                "dbo.Shoppes",
                c => new
                    {
                        StoreName = c.String(nullable: false, maxLength: 30),
                        StoreId = c.Int(nullable: false),
                        City = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        GSTIN = c.String(),
                    })
                .PrimaryKey(t => new { t.StoreName, t.StoreId })
                .Index(t => t.ZipCode);
            
            CreateTable(
                "shop.PatientDoctors",
                c => new
                    {
                        Patient_PatientId = c.Int(nullable: false),
                        Doctor_DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Patient_PatientId, t.Doctor_DoctorId })
                .ForeignKey("shop.Patients", t => t.Patient_PatientId, cascadeDelete: true)
                .ForeignKey("shop.Doctors", t => t.Doctor_DoctorId, cascadeDelete: true)
                .Index(t => t.Patient_PatientId)
                .Index(t => t.Doctor_DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("shop.PatientDoctors", "Doctor_DoctorId", "shop.Doctors");
            DropForeignKey("shop.PatientDoctors", "Patient_PatientId", "shop.Patients");
            DropForeignKey("visit.Visitor", "ProductID", "shop.ShopProducts");
            DropIndex("shop.PatientDoctors", new[] { "Doctor_DoctorId" });
            DropIndex("shop.PatientDoctors", new[] { "Patient_PatientId" });
            DropIndex("dbo.Shoppes", new[] { "ZipCode" });
            DropIndex("visit.Visitor", new[] { "ProductID" });
            DropTable("shop.PatientDoctors");
            DropTable("dbo.Shoppes");
            DropTable("shop.Samples");
            DropTable("shop.Patients");
            DropTable("shop.Doctors");
            DropTable("shop.ShopProducts");
            DropTable("visit.Visitor");
        }
    }
}
