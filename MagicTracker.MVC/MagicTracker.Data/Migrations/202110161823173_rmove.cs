namespace MagicTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rmove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Card", "CardType2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Card", "CardType2", c => c.Int());
        }
    }
}
