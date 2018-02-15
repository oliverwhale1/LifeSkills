using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LifeSkillsProject.Models;

namespace LifeSkillsProject.Controllers
{
    public class HomeController : Controller
    {
        private BanksDBEntities _db = new BanksDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Budget()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Budget(BudgetC model)
        {

            if (model.Salary < 11500)
            {
                model.Tax = 0;
            }
            else if (model.Salary < 45000)
            {
                model.Tax = Math.Round(0.2 * model.Salary, 2);
            }
            else if (model.Salary < 150000)
            {
                model.Tax = Math.Round(0.4 * model.Salary, 2);
            }
            else
            {
                model.Tax = Math.Round(0.45 * model.Salary, 2);
            }

            model.NInumber = Math.Round(0.12 * model.Salary, 2);
            model.DispMonth = Math.Round((model.Salary / 12) - model.Rent - model.Bills - model.Subscriptions - model.Other - (model.NInumber / 12) - (model.Tax / 12), 2);
            model.DispDay = Math.Round(model.DispMonth / 31, 2);

            return View(model);
 
        }

        public ActionResult Banking(int? id)
        {
            var banks = from p in _db.Banks select p;
            return View(banks);
        }
    }
}