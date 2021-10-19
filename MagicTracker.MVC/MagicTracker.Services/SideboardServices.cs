using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicTracker.Data;
using MagicTracker.Models;

namespace MagicTracker.Services
{
    public class SideboardServices
    {
        public bool CreateSideboard(SideboardCreate model)
        {
            var entity =
                new Sideboard()
                {
                    CardCount = model.CardCount,
                    CardStyle = model.CardStyle,
                    DeckId = model.DeckId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sideboardss.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }

        public IEnumerable<SideboardListItem> GetSideboards()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sideboardss
                        .Select(
                            e =>
                                new SideboardListItem
                                {
                                    SideboardId = e.SideboardId,
                                    CardCount = e.CardCount,
                                    CardStyle = e.CardStyle,
                                    DeckId = e.DeckId
                                });
                return query.ToArray();
            }
        }

        public SideboardDetail GetSideboardById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Sideboardss.Single(e => e.SideboardId == id);
                return
                    new SideboardDetail
                    {
                        SideboardId = entity.SideboardId,
                        CardCount = entity.CardCount,
                        CardStyle = entity.CardStyle,
                        DeckId = entity.DeckId
                    };
            }
        }

        //public IEnumerable<CardDetail> GetCardsInDeck(int id) { }

        public bool UpdateSideboard(SideboardEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Sideboardss.Single(e => e.SideboardId == model.SideboardId);

                entity.SideboardId = model.SideboardId;
                entity.CardCount = model.CardCount;
                entity.CardStyle = model.CardStyle;
                entity.DeckId = model.DeckId;



                return ctx.SaveChanges() >= 1;
            }
        }

        public bool DeleteSideboard(int sideboardId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Sideboardss.Single(e => e.SideboardId == sideboardId);

                ctx.Sideboardss.Remove(entity);

                return ctx.SaveChanges() >= 1;
            }
        }
    }
}
