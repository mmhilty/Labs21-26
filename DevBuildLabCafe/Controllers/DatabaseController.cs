using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevBuildLabCafe.Models;

namespace DevBuildLabCafe.Controllers
{
    public class DatabaseController : Controller
    {
        // GET: Database
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }

        #region Customer Actions

        public ActionResult AddCustomer()
        {
            return View();
        }

        public ActionResult SaveNewCustomer(Customer newCustomer)
        {
            //imports database
            DevBuildLabCafeDBEntities ORM = new DevBuildLabCafeDBEntities();


            //saving goes here
            List<Customer> customersList = ORM.Customers.Where(
                    c => c.Email.Contains(newCustomer.Email)                        
                    ).ToList();

            if(customersList.Count() >= 1)
            {
                return RedirectToAction("Index");
            }

            else
            {

                ORM.Customers.Add(newCustomer);
                ORM.SaveChanges();

                return RedirectToAction("Index");

            }

        }
        #endregion
        #region Item Actions
        public ActionResult ViewItems()
        {
            //imports database
            DevBuildLabCafeDBEntities ORM = new DevBuildLabCafeDBEntities();

            ViewBag.itemList = ORM.Items.ToList();


            return View(); 
        }

        public ActionResult AddNewItem()
        {
            return View();
        }

        public ActionResult SaveNewItem(Item newItem)
        {
            DevBuildLabCafeDBEntities ORM = new DevBuildLabCafeDBEntities();

            //saving goes here
            List<Item> customersList = ORM.Items.Where(
                    c => c.ItemName.Contains(newItem.ItemName)
                    ).ToList();

            if (customersList.Count() >= 1)
            {
                return RedirectToAction("ViewItems");
            }

            else
            {

                ORM.Items.Add(newItem);
                ORM.SaveChanges();

                return RedirectToAction("ViewItems");

            }

        }
        #endregion
    }
}