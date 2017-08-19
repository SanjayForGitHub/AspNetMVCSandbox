using AspNetMVCSandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace AspNetMVCSandbox.Controllers
{
    public class DashboardController : Controller
    {
        NorthwindDbContext dbContext = new NorthwindDbContext();
        // GET: Dashboard
        public ActionResult Index(string customerID)
        {
            //if(String.IsNullOrEmpty(customerID))
            //var customers = dbContext.CustOrderHist(customerID).ToList();
            //var customers = dbContext.CustOrderHist("ALFKI").ToList();
            //return View(customers);
            return View();
        }
        public ActionResult CustomerOrderHist(jQueryDataTableParamModel param) {
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = 97,
                iTotalDisplayRecords = 3,
                aaData = new List<string[]>() {
                    new string[] {"1", "Microsoft", "Redmond", "USA"},
                    new string[] {"2", "Google", "Mountain View", "USA"},
                    new string[] {"3", "Gowi", "Pancevo", "Serbia"}
                    }
            },
        JsonRequestBehavior.AllowGet);

        }
        public ActionResult CustomerOrderHist2(jQueryDataTableParamModel param)
        {
            var customers = dbContext.CustOrderHist("ALFKI").ToList();
            var result = from c in customers
                         select new[] { c.ProductID.ToString(), c.ProductName, c.Total.ToString()};

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = result.Count(),
                iTotalDisplayRecords = result.Count(),
                aaData = result
            },
        JsonRequestBehavior.AllowGet);

        }
    }
}