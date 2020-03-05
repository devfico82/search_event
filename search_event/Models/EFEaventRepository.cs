using search_event.Models;
using System.Collections.Generic;
using System.Linq;

namespace search_event.Models
{
    public class EFEaventRepository : IEaventRepository
    {
        private ApplicationDbContext context;

        public EFEaventRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Eavent> Eavents => context.Eavents;

        public void SaveEavent(Eavent eavent)
        {
            if (eavent.EaventID == 0)
            {
                context.Eavents.Add(eavent);
            }
            else
            {
                Eavent dbEntry = context.Eavents
                .FirstOrDefault(p => p.EaventID == eavent.EaventID);
                if (dbEntry != null)
                {
                    dbEntry.Name = eavent.Name;
                    dbEntry.Category = eavent.Category;
                }
            }
            context.SaveChanges();
        }

        public Eavent DeleteEavent(int eaventID)
        {
            Eavent dbEntry = context.Eavents
            .FirstOrDefault(p => p.EaventID == eaventID);
            if (dbEntry != null)
            {
                context.Eavents.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}