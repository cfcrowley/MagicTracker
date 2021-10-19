namespace MagicTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trying : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Deck", "SideboardId", "dbo.Sideboard");
            DropIndex("dbo.Deck", new[] { "SideboardId" });
            AddColumn("dbo.Sideboard", "CardStyle", c => c.String(nullable: false));
            AddColumn("dbo.Sideboard", "DeckId", c => c.Int(nullable: false));
            CreateIndex("dbo.Sideboard", "DeckId");
            AddForeignKey("dbo.Sideboard", "DeckId", "dbo.Deck", "DeckId", cascadeDelete: false);
            DropColumn("dbo.Deck", "SideboardId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Deck", "SideboardId", c => c.Int());
            DropForeignKey("dbo.Sideboard", "DeckId", "dbo.Deck");
            DropIndex("dbo.Sideboard", new[] { "DeckId" });
            DropColumn("dbo.Sideboard", "DeckId");
            DropColumn("dbo.Sideboard", "CardStyle");
            CreateIndex("dbo.Deck", "SideboardId");
            AddForeignKey("dbo.Deck", "SideboardId", "dbo.Sideboard", "SideboardId");
        }
    }
}
