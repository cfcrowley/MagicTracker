namespace MagicTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class theboys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Card", "DeckId", "dbo.Deck");
            DropForeignKey("dbo.Card", "SideboardId", "dbo.Sideboard");
            DropIndex("dbo.Card", new[] { "DeckId" });
            DropIndex("dbo.Card", new[] { "SideboardId" });
            AlterColumn("dbo.Card", "DeckId", c => c.Int());
            AlterColumn("dbo.Card", "SideboardId", c => c.Int());
            CreateIndex("dbo.Card", "DeckId");
            CreateIndex("dbo.Card", "SideboardId");
            AddForeignKey("dbo.Card", "DeckId", "dbo.Deck", "DeckId");
            AddForeignKey("dbo.Card", "SideboardId", "dbo.Sideboard", "SideboardId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Card", "SideboardId", "dbo.Sideboard");
            DropForeignKey("dbo.Card", "DeckId", "dbo.Deck");
            DropIndex("dbo.Card", new[] { "SideboardId" });
            DropIndex("dbo.Card", new[] { "DeckId" });
            AlterColumn("dbo.Card", "SideboardId", c => c.Int(nullable: false));
            AlterColumn("dbo.Card", "DeckId", c => c.Int(nullable: false));
            CreateIndex("dbo.Card", "SideboardId");
            CreateIndex("dbo.Card", "DeckId");
            AddForeignKey("dbo.Card", "SideboardId", "dbo.Sideboard", "SideboardId", cascadeDelete: true);
            AddForeignKey("dbo.Card", "DeckId", "dbo.Deck", "DeckId", cascadeDelete: true);
        }
    }
}
