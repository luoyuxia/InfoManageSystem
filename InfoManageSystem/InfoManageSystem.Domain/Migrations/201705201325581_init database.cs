namespace InfoManageSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdatabase : DbMigration
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
                        minNum = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.GoodsStorage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Goods_Id = c.Int(),
                        WareHouse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goods", t => t.Goods_Id)
                .ForeignKey("dbo.WareHouse", t => t.WareHouse_Id)
                .Index(t => t.Goods_Id)
                .Index(t => t.WareHouse_Id);
            
            CreateTable(
                "dbo.WareHouse",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, storeType: "nvarchar"),
                        Location = c.String(maxLength: 50, storeType: "nvarchar"),
                        capacity = c.Int(nullable: false),
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
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.WareHousingItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Goods_Id = c.Int(),
                        WareHouse_Id = c.Int(),
                        WareHousingList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goods", t => t.Goods_Id)
                .ForeignKey("dbo.WareHouse", t => t.WareHouse_Id)
                .ForeignKey("dbo.WareHousingList", t => t.WareHousingList_Id)
                .Index(t => t.Goods_Id)
                .Index(t => t.WareHouse_Id)
                .Index(t => t.WareHousingList_Id);
            
            CreateTable(
                "dbo.ShipmentItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SellPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Goods_Id = c.Int(),
                        ShipmentList_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goods", t => t.Goods_Id)
                .ForeignKey("dbo.ShipmentList", t => t.ShipmentList_Id)
                .Index(t => t.Goods_Id)
                .Index(t => t.ShipmentList_Id);
            
            CreateTable(
                "dbo.ShipmentList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ShipmentTime = c.DateTime(nullable: false, precision: 0),
                        ShipmentAddress = c.String(maxLength: 50, storeType: "nvarchar"),
                        Dealers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dealers", t => t.Dealers_Id)
                .Index(t => t.Dealers_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipmentItem", "ShipmentList_Id", "dbo.ShipmentList");
            DropForeignKey("dbo.ShipmentList", "Dealers_Id", "dbo.Dealers");
            DropForeignKey("dbo.ShipmentItem", "Goods_Id", "dbo.Goods");
            DropForeignKey("dbo.WareHousingItem", "WareHousingList_Id", "dbo.WareHousingList");
            DropForeignKey("dbo.WareHousingItem", "WareHouse_Id", "dbo.WareHouse");
            DropForeignKey("dbo.WareHousingItem", "Goods_Id", "dbo.Goods");
            DropForeignKey("dbo.WareHousingList", "Employee_Id", "dbo.Employee");
            DropForeignKey("dbo.GoodsStorage", "WareHouse_Id", "dbo.WareHouse");
            DropForeignKey("dbo.GoodsStorage", "Goods_Id", "dbo.Goods");
            DropForeignKey("dbo.Goods", "Category_Id", "dbo.Category");
            DropIndex("dbo.ShipmentList", new[] { "Dealers_Id" });
            DropIndex("dbo.ShipmentItem", new[] { "ShipmentList_Id" });
            DropIndex("dbo.ShipmentItem", new[] { "Goods_Id" });
            DropIndex("dbo.WareHousingItem", new[] { "WareHousingList_Id" });
            DropIndex("dbo.WareHousingItem", new[] { "WareHouse_Id" });
            DropIndex("dbo.WareHousingItem", new[] { "Goods_Id" });
            DropIndex("dbo.WareHousingList", new[] { "Employee_Id" });
            DropIndex("dbo.GoodsStorage", new[] { "WareHouse_Id" });
            DropIndex("dbo.GoodsStorage", new[] { "Goods_Id" });
            DropIndex("dbo.Goods", new[] { "Category_Id" });
            DropTable("dbo.ShipmentList");
            DropTable("dbo.ShipmentItem");
            DropTable("dbo.WareHousingItem");
            DropTable("dbo.WareHousingList");
            DropTable("dbo.Employee");
            DropTable("dbo.Dealers");
            DropTable("dbo.WareHouse");
            DropTable("dbo.GoodsStorage");
            DropTable("dbo.Goods");
            DropTable("dbo.Category");
        }
    }
}
