using GOOS_Sample.Models.dataModels;
using GOOS_Sample.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOOS_Sample.Models;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {
        private IBudgetService budgetService;

        public BudgetController()
        {
            this.budgetService = new BudgetService();
        }

        public BudgetController(IBudgetService budgetServiceStub)
        {
            this.budgetService = budgetServiceStub;
        }

        // GET: Budget
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BudgetAddViewModel model)
        {
            

            this.budgetService.Create(model);
           
            ViewBag.Message = "added successfully";
            return View(model);
        }
    }
}