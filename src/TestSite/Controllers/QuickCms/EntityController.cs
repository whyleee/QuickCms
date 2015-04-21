using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using QuickCms;
using TestSite.Models;

namespace TestSite.Controllers.QuickCms
{
    public class EntityController : Controller
    {
        private readonly IRepositoryFactory _repoFac;

        public EntityController(IRepositoryFactory repoFac)
        {
            _repoFac = repoFac;
        }

        public IActionResult Index(string entityName)
        {
            using (var repo = _repoFac.CreateRepository(entityName))
            {
                var model = new EntityIndexViewModel
                {
                    EntityName = entityName,
                    Entities = repo.GetAll().Cast<object>().ToList()
                };

                return View(model);
            }
        }
    }
}