using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicTracker.Data;
using MagicTracker.Models;

namespace MagicTracker.Services
{
    public class CardServices
    {
        public bool CreateCard(CardCreate model)
        {
            var entity =
                new Card()
                {
                    Name = model.Name,
                    CardType = model.CardType,
                    ManaValue = model.ManaValue
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cards.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }

        public IEnumerable<CardListItem> GetCards()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cards
                        .Select(
                            e =>
                                new CardListItem
                                {
                                    CardId = e.CardId,
                                    Name = e.Name,
                                    CardType = e.CardType,
                                    ManaValue = e.ManaValue
                                });
                return query.ToArray();
            }
        }

        public CardDetail GetCardById(int id)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cards.Single(e => e.CardId == id);
                return
                    new CardDetail
                    {
                        CardId = entity.CardId,
                        Name = entity.Name,
                        CardType = entity.CardType,
                        ManaValue = entity.ManaValue,
                        DeckId = entity.DeckId,
                        SideboardId = entity.SideboardId
                    };
            }
        }

        public bool UpdateCard(CardEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cards.Single(e => e.CardId == model.CardId);

                entity.CardId = model.CardId;
                entity.Name = model.Name;
                entity.CardType = model.CardType;
                entity.ManaValue = model.ManaValue;
                entity.DeckId = model.DeckId;
                entity.SideboardId = model.SideboardId;

                return ctx.SaveChanges() >= 1;
            }
        }

        public bool DeleteCard(int cardId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Cards.Single(e => e.CardId == cardId);

                ctx.Cards.Remove(entity);

                return ctx.SaveChanges() >= 1;
            }
        }
    }
}
