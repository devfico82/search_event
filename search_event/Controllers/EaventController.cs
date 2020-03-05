using Microsoft.AspNetCore.Mvc;
using System.Linq;
using search_event.Models.ViewModels;

namespace search_event.Models
{
    public class EaventController : Controller
    {
        private IEaventRepository repository;
        public int PageSize = 9;

        public EaventController(IEaventRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int eaventPage = 1)
            => View(new EaventsListViewModel
             {
                 Eavents = repository.Eavents
                 .Where(p => category == null || p.Category == category)
                 .OrderBy(p => p.EaventID)
                 .Skip((eaventPage - 1) * PageSize)
                 .Take(PageSize),
                 PagingInfo = new PagingInfo
                 {
                     CurrentPage = eaventPage,
                     ItemsPerPage = PageSize,
                     TotalItems = category == null ?
                         repository.Eavents.Count() :
                         repository.Eavents.Where(e =>
                         e.Category == category).Count()
                 },
                CurrentCategory = category
            });
    }
}