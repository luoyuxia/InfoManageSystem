namespace InfoManageSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addshipmentitemreference : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShipmentItem", "WareHouseId", c => c.Int(nullable: false));
            CreateIndex("dbo.ShipmentItem", "WareHouseId");
            AddForeignKey("dbo.ShipmentItem", "WareHouseId", "dbo.WareHouse", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShipmentItem", "WareHouseId", "dbo.WareHouse");
            DropIndex("dbo.ShipmentItem", new[] { "WareHouseId" });
            DropColumn("dbo.ShipmentItem", "WareHouseId");
        }
    }
}
