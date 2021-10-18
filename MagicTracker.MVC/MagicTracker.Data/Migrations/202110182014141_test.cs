namespace MagicTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Deck", "SideboardId", "dbo.Sideboard");
            DropIndex("dbo.Deck", new[] { "SideboardId" });
            AlterColumn("dbo.Deck", "SideboardId", c => c.Int());
            CreateIndex("dbo.Deck", "SideboardId");
            AddForeignKey("dbo.Deck", "SideboardId", "dbo.Sideboard", "SideboardId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deck", "SideboardId", "dbo.Sideboard");
            DropIndex("dbo.Deck", new[] { "SideboardId" });
            AlterColumn("dbo.Deck", "SideboardId", c => c.Int(nullable: false));
            CreateIndex("dbo.Deck", "SideboardId");
            AddForeignKey("dbo.Deck", "SideboardId", "dbo.Sideboard", "SideboardId", cascadeDelete: true);
        }
    }
}
