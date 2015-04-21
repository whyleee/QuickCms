using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using QuickCms;
using TestSite.Models;

namespace TestSite.Controllers
{
    public class AdminController : Controller
    {
        private readonly ITypeDefinitionProvider _typeDefinitionProvider;

        public AdminController(ITypeDefinitionProvider typeDefinitionProvider)
        {
            _typeDefinitionProvider = typeDefinitionProvider;
        }

        public IActionResult Index()
        {
            var model = new AdminIndexViewModel
            {
                FoundTypes = _typeDefinitionProvider.GetTypeDefinitions().ToList()
            };

            return View(model);
        }
    }
}