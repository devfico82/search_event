using Microsoft.AspNetCore.Mvc;
using System.Linq;
using search_event.Models;

namespace search_event.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IEaventRepository repository;
        public NavigationMenuViewComponent(IEaventRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Eavents
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}