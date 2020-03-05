using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using search_event.Models;

namespace search_event.Controllers
{
    public class GoogleMapsController : Controller
    {

        private IEaventRepository repository;

        public GoogleMapsController(IEaventRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Eavents);

    }
}