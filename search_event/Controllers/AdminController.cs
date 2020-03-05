using Microsoft.AspNetCore.Mvc;
using search_event.Models;
using System.Linq;

namespace search_event.Controllers
{
    public class AdminController : Controller
    {
        private IEaventRepository repository;
        public AdminController(IEaventRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View(repository.Eavents);

        public ViewResult Edit(int eaventId) =>
            View(repository.Eavents
            .FirstOrDefault(p => p.EaventID == eaventId));

        [HttpPost]
        public IActionResult Edit(Eavent eavent)
        {
            if (ModelState.IsValid)
            {
                repository.SaveEavent(eavent);
                TempData["message"] = $"Zapisano {eavent.Name}.";
                return RedirectToAction("Index");
            }
            else
            {
                // Błąd w wartościach danych.
                return View(eavent);
            }
        }

        public ViewResult Create() => View("Edit", new Eavent());

        [HttpPost]
        public IActionResult Delete(int eaventId)
        {
            Eavent deletedEavent = repository.DeleteEavent(eaventId);
            if (deletedEavent != null)
            {
                TempData["message"] = $"Usunięto {deletedEavent.Name}.";
            }
            return RedirectToAction("Index");
        }
    }
}