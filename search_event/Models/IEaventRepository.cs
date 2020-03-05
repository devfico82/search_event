using System.Linq;

namespace search_event.Models
{
    public interface IEaventRepository
    {
        IQueryable<Eavent> Eavents { get; }

        void SaveEavent(Eavent eavent);
        Eavent DeleteEavent(int eaventID);
    }
}