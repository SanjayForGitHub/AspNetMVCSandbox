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
            var customers = dbContext.CustOrderHist("ALFKI").ToList();
            return View(customers);
        }
    }
}