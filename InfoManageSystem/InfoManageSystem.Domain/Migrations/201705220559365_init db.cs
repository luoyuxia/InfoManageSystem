namespace InfoManageSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20, storeType: "nvarchar"),
                        Description = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30, storeType: "nvarchar"),
                        minNum = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.GoodsStorage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        WareHouseId = c.Int(nullable: false),
                        GoodsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goods", t => t.GoodsId, cascadeDelete: true)
                .ForeignKey("dbo.WareHouse", t => t.WareHouseId, cascadeDelete: true)
                .Index(t => t.WareHouseId)
                .Index(t => t.GoodsId);
            
            CreateTable(
                "dbo.WareHouse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, storeType: "nvarchar"),
                        Location = c.String(maxLength: 50, storeType: "nvarchar"),
                        Capacity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dealers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 20, storeType: "nvarchar"),
                        Phone = c.String(maxLength: 20, storeType: "nvarchar"),
                        Address = c.String(maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShipmentList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShipmentTime = c.DateTime(nullable: false, precision: 0),
                        ShipmentAddress = c.String(maxLength: 50, storeType: "nvarchar"),
                        DealersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dealers", t => t.DealersId, cascadeDelete: true)
                .Index(t => t.DealersId);
            
            CreateTable(
                "dbo.ShipmentItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        GoodsId = c.Int(nullable: false),
                        ShipmentList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goods", t => t.GoodsId, cascadeDelete: true)
                .ForeignKey("dbo.ShipmentList", t => t.ShipmentList_Id)
                .Index(t => t.GoodsId)
                .Index(t => t.ShipmentList_Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Account = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        Password = c.String(nullable: false, maxLength: 200, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        Avatar = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Role = c.Int(nullable: false),
                        BirthDay = c.DateTime(nullable: false, precision: 0),
                        Phone = c.String(maxLength: 20, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WareHousingList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WareHousingTime = c.DateTime(nullable: false, precision: 0),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.WareHousingItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        WareHouseId = c.Int(nullable: false),
                        GoodsId = c.Int(nullable: false),
                        WareHousingList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goods", t => t.GoodsId, cascadeDelete: true)
                .ForeignKey("dbo.WareHouse", t => t.WareHouseId, cascadeDelete: true)
                .ForeignKey("dbo.WareHousingList", t => t.WareHousingList_Id)
                .Index(t => t.WareHouseId)
                .Index(t => t.GoodsId)
                .Index(t => t.WareHousingList_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WareHousingItem", "WareHousingList_Id", "dbo.WareHousingList");
            DropForeignKey("dbo.WareHousingItem", "WareHouseId", "dbo.WareHouse");
            DropForeignKey("dbo.WareHousingItem", "GoodsId", "dbo.Goods");
            DropForeignKey("dbo.WareHousingList", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.ShipmentItem", "ShipmentList_Id", "dbo.ShipmentList");
            DropForeignKey("dbo.ShipmentItem", "GoodsId", "dbo.Goods");
            DropForeignKey("dbo.ShipmentList", "DealersId", "dbo.Dealers");
            DropForeignKey("dbo.GoodsStorage", "WareHouseId", "dbo.WareHouse");
            DropForeignKey("dbo.GoodsStorage", "GoodsId", "dbo.Goods");
            DropForeignKey("dbo.Goods", "CategoryId", "dbo.Category");
            DropIndex("dbo.WareHousingItem", new[] { "WareHousingList_Id" });
            DropIndex("dbo.WareHousingItem", new[] { "GoodsId" });
            DropIndex("dbo.WareHousingItem", new[] { "WareHouseId" });
            DropIndex("dbo.WareHousingList", new[] { "EmployeeId" });
            DropIndex("dbo.ShipmentItem", new[] { "ShipmentList_Id" });
            DropIndex("dbo.ShipmentItem", new[] { "GoodsId" });
            DropIndex("dbo.ShipmentList", new[] { "DealersId" });
            DropIndex("dbo.GoodsStorage", new[] { "GoodsId" });
            DropIndex("dbo.GoodsStorage", new[] { "WareHouseId" });
            DropIndex("dbo.Goods", new[] { "CategoryId" });
            DropTable("dbo.WareHousingItem");
            DropTable("dbo.WareHousingList");
            DropTable("dbo.Employee");
            DropTable("dbo.ShipmentItem");
            DropTable("dbo.ShipmentList");
            DropTable("dbo.Dealers");
            DropTable("dbo.WareHouse");
            DropTable("dbo.GoodsStorage");
            DropTable("dbo.Goods");
            DropTable("dbo.Category");
        }
    }
}
