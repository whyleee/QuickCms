using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNet.Mvc;
using QuickCms;
using TestSite.Models;

namespace TestSite.Controllers.QuickCms
{
    public class EntityController : Controller
    {
        private readonly IRepositoryFactory _repoFac;
        private readonly IModelBuilder _modelBuilder;

        public EntityController(IRepositoryFactory repoFac, IModelBuilder modelBuilder)
        {
            _repoFac = repoFac;
            _modelBuilder = modelBuilder;
        }

        public IActionResult Index(string entityName)
        {
            using (var repo = _repoFac.CreateRepository(entityName))
            {
                var model = new EntityIndexViewModel
                {
                    EntityName = entityName,
                    Entities = repo.GetAll().Cast<object>()
                        .Select(item => _modelBuilder.GetModel(item))
                        .ToList()
                };

                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Edit(string entityName, object id)
        {
            using (var repo = _repoFac.CreateRepository(entityName))
            {
                var model = _modelBuilder.GetModel(repo.Get(id));

                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Edit(ItemModel model)
        {
            if (ModelState.IsValid)
            {
                using (var repo = _repoFac.CreateRepository(model.TypeName))
                {
                    repo.Save(model.Item);
                }

                return RedirectToAction("Index", new { entityName = model.TypeName });
            }

            return View(model);
        }
    }
}