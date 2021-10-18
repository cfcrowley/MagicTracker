namespace MagicTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class neww : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DeckCard", "Deck_DeckId", "dbo.Deck");
            DropForeignKey("dbo.DeckCard", "Card_CardId", "dbo.Card");
            DropForeignKey("dbo.Sideboard", "Card_CardId", "dbo.Card");
            DropForeignKey("dbo.Deck", "Sideboard_SideboardId", "dbo.Sideboard");
            DropIndex("dbo.Deck", new[] { "Sideboard_SideboardId" });
            DropIndex("dbo.Sideboard", new[] { "Card_CardId" });
            DropIndex("dbo.DeckCard", new[] { "Deck_DeckId" });
            DropIndex("dbo.DeckCard", new[] { "Card_CardId" });
            RenameColumn(table: "dbo.Deck", name: "Sideboard_SideboardId", newName: "SideboardId");
            AddColumn("dbo.Card", "DeckId", c => c.Int(nullable: false));
            AddColumn("dbo.Card", "SideboardId", c => c.Int(nullable: false));
            AddColumn("dbo.Sideboard", "CardCount", c => c.Int(nullable: false));
            AlterColumn("dbo.Deck", "SideboardId", c => c.Int(nullable: false));
            CreateIndex("dbo.Card", "DeckId");
            CreateIndex("dbo.Card", "SideboardId");
            CreateIndex("dbo.Deck", "SideboardId");
            AddForeignKey("dbo.Card", "DeckId", "dbo.Deck", "DeckId", cascadeDelete: false);
            AddForeignKey("dbo.Card", "SideboardId", "dbo.Sideboard", "SideboardId", cascadeDelete: false);
            AddForeignKey("dbo.Deck", "SideboardId", "dbo.Sideboard", "SideboardId", cascadeDelete: false);
            DropColumn("dbo.Sideboard", "Card_CardId");
            DropTable("dbo.DeckCard");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DeckCard",
                c => new
                    {
                        Deck_DeckId = c.Int(nullable: false),
                        Card_CardId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Deck_DeckId, t.Card_CardId });
            
            AddColumn("dbo.Sideboard", "Card_CardId", c => c.Int());
            DropForeignKey("dbo.Deck", "SideboardId", "dbo.Sideboard");
            DropForeignKey("dbo.Card", "SideboardId", "dbo.Sideboard");
            DropForeignKey("dbo.Card", "DeckId", "dbo.Deck");
            DropIndex("dbo.Deck", new[] { "SideboardId" });
            DropIndex("dbo.Card", new[] { "SideboardId" });
            DropIndex("dbo.Card", new[] { "DeckId" });
            AlterColumn("dbo.Deck", "SideboardId", c => c.Int());
            DropColumn("dbo.Sideboard", "CardCount");
            DropColumn("dbo.Card", "SideboardId");
            DropColumn("dbo.Card", "DeckId");
            RenameColumn(table: "dbo.Deck", name: "SideboardId", newName: "Sideboard_SideboardId");
            CreateIndex("dbo.DeckCard", "Card_CardId");
            CreateIndex("dbo.DeckCard", "Deck_DeckId");
            CreateIndex("dbo.Sideboard", "Card_CardId");
            CreateIndex("dbo.Deck", "Sideboard_SideboardId");
            AddForeignKey("dbo.Deck", "Sideboard_SideboardId", "dbo.Sideboard", "SideboardId");
            AddForeignKey("dbo.Sideboard", "Card_CardId", "dbo.Card", "CardId");
            AddForeignKey("dbo.DeckCard", "Card_CardId", "dbo.Card", "CardId", cascadeDelete: true);
            AddForeignKey("dbo.DeckCard", "Deck_DeckId", "dbo.Deck", "DeckId", cascadeDelete: true);
        }
    }
}
