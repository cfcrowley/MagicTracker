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
                return ctx.SaveChanges() == 1;
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

        public CardDetail GetCardById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cards.Single(e => e.CardId == id);
                return
                    new CardDetail
                    {
                        CardId = entity.CardId,
                        Name = entity.Name,
                        CardType = entity.CardType,
                        ManaValue = entity.ManaValue
                    };
            }
        }

        public bool UpdateCard(CardEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cards.Single(e => e.CardId == model.CardId);

                entity.CardId = model.CardId;
                entity.Name = model.Name;
                entity.CardType = model.CardType;
                entity.ManaValue = model.ManaValue;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCard(int cardId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cards.Single(e => e.CardId == cardId);

                ctx.Cards.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
