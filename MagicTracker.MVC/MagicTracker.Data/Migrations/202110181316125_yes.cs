namespace MagicTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Deck", "SideboardId", "dbo.Sideboard");
            DropIndex("dbo.Deck", new[] { "SideboardId" });
            RenameColumn(table: "dbo.Deck", name: "SideboardId", newName: "Sideboard_SideboardId");
            AlterColumn("dbo.Deck", "Sideboard_SideboardId", c => c.Int());
            CreateIndex("dbo.Deck", "Sideboard_SideboardId");
            AddForeignKey("dbo.Deck", "Sideboard_SideboardId", "dbo.Sideboard", "SideboardId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deck", "Sideboard_SideboardId", "dbo.Sideboard");
            DropIndex("dbo.Deck", new[] { "Sideboard_SideboardId" });
            AlterColumn("dbo.Deck", "Sideboard_SideboardId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Deck", name: "Sideboard_SideboardId", newName: "SideboardId");
            CreateIndex("dbo.Deck", "SideboardId");
            AddForeignKey("dbo.Deck", "SideboardId", "dbo.Sideboard", "SideboardId", cascadeDelete: true);
        }
    }
}
