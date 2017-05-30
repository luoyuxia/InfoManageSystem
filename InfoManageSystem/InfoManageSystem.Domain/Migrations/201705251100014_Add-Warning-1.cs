namespace InfoManageSystem.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWarning1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Warnings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GoodsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goods", t => t.GoodsId, cascadeDelete: true)
                .Index(t => t.GoodsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Warnings", "GoodsId", "dbo.Goods");
            DropIndex("dbo.Warnings", new[] { "GoodsId" });
            DropTable("dbo.Warnings");
        }
    }
}
