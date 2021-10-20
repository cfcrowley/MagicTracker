using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicTracker.Data;
using MagicTracker.Models;

namespace MagicTracker.Services
{
    public class DeckServices
    {
        public bool CreateDeck(DeckCreate model)
        {
            var entity =
                new Deck()
                {
                    CardCount = model.CardCount,
                    DeckType = model.DeckType,
                    DeckStyle = model.DeckStyle,
                    Commander = model.Commander,
                    Companion = model.Companion
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Decks.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }

        public IEnumerable<DeckListItem> GetDecks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Decks
                        .Select(
                            e =>
                                new DeckListItem
                                {
                                    DeckId = e.DeckId,
                                    DeckType = e.DeckType,
                                    CardCount = e.CardCount,
                                    DeckStyle = e.DeckStyle
                                });
                return query.ToArray();
            }
        }

        public DeckDetail GetDeckById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Decks.Single(e => e.DeckId == id);
                return
                    new DeckDetail
                    {
                        DeckId = entity.DeckId,
                        DeckType = entity.DeckType,
                        CardCount = entity.CardCount,
                        Commander = entity.Commander,
                        Companion = entity.Companion,
                        DeckStyle = entity.DeckStyle
                    };
            }
        }

        //public IEnumerable<CardDetail> GetCardsInDeck(int id) { }

        public bool UpdateDeck(DeckEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Decks.Single(e => e.DeckId == model.DeckId);

                entity.DeckId = model.DeckId;
                entity.DeckType = model.DeckType;
                entity.CardCount = model.CardCount;
                entity.DeckStyle = model.DeckStyle;
                entity.Commander = model.Commander;
                entity.Companion = model.Companion;
                
               

                return ctx.SaveChanges() >= 1;
            }
        }

        public bool DeleteDeck(int deckId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Decks.Single(e => e.DeckId == deckId);

                ctx.Decks.Remove(entity);

                return ctx.SaveChanges() >= 1;
            }
        }
    }

}
