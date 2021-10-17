namespace MagicTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Deck", "Card_CardId", "dbo.Card");
            DropIndex("dbo.Deck", new[] { "Card_CardId" });
            CreateTable(
                "dbo.DeckCard",
                c => new
                    {
                        Deck_DeckId = c.Int(nullable: false),
                        Card_CardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Deck_DeckId, t.Card_CardId })
                .ForeignKey("dbo.Deck", t => t.Deck_DeckId, cascadeDelete: true)
                .ForeignKey("dbo.Card", t => t.Card_CardId, cascadeDelete: true)
                .Index(t => t.Deck_DeckId)
                .Index(t => t.Card_CardId);
            
            AddColumn("dbo.Deck", "DeckType", c => c.Int(nullable: false));
            AddColumn("dbo.Deck", "CardCount", c => c.Int(nullable: false));
            AddColumn("dbo.Deck", "DeckStyle", c => c.String(nullable: false));
            AddColumn("dbo.Deck", "Commander", c => c.String());
            AddColumn("dbo.Deck", "Companion", c => c.String());
            AddColumn("dbo.Deck", "SideboardId", c => c.Int(nullable: false));
            CreateIndex("dbo.Deck", "SideboardId");
            AddForeignKey("dbo.Deck", "SideboardId", "dbo.Sideboard", "SideboardId", cascadeDelete: true);
            DropColumn("dbo.Deck", "Card_CardId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Deck", "Card_CardId", c => c.Int());
            DropForeignKey("dbo.Deck", "SideboardId", "dbo.Sideboard");
            DropForeignKey("dbo.DeckCard", "Card_CardId", "dbo.Card");
            DropForeignKey("dbo.DeckCard", "Deck_DeckId", "dbo.Deck");
            DropIndex("dbo.DeckCard", new[] { "Card_CardId" });
            DropIndex("dbo.DeckCard", new[] { "Deck_DeckId" });
            DropIndex("dbo.Deck", new[] { "SideboardId" });
            DropColumn("dbo.Deck", "SideboardId");
            DropColumn("dbo.Deck", "Companion");
            DropColumn("dbo.Deck", "Commander");
            DropColumn("dbo.Deck", "DeckStyle");
            DropColumn("dbo.Deck", "CardCount");
            DropColumn("dbo.Deck", "DeckType");
            DropTable("dbo.DeckCard");
            CreateIndex("dbo.Deck", "Card_CardId");
            AddForeignKey("dbo.Deck", "Card_CardId", "dbo.Card", "CardId");
        }
    }
}
