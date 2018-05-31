using GC_CoffeeLab.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GC_CoffeeLab.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CoffeeEntities ORM = new CoffeeEntities();

            ViewBag.Items = ORM.Items.ToList();
            ViewBag.Users = ORM.Users.ToList();
            return View();
        }

        public ActionResult About(Item data)
        {
            CoffeeEntities ORM = new CoffeeEntities();
            if (ModelState.IsValid)
            {
                
                ORM.Items.Add(data);
                
                ORM.SaveChanges();
                ViewBag.message = $"{data.Description} has been added";
            }
            else
            {
                ViewBag.message = "Item is not valid, cannot add to DB.";
            }

            return View();
        }

            
        }

    //we pass in the ItemID so that we can remove a certain object
    public ActionResult Contact(int ID)
    {
        CoffeeEntities ORM = new CoffeeEntities();
        //we build this object so that we can make a transaction
        DbContextTransaction DeleteCustomerTransaction = ORM.Database.BeginTransaction();
        Item temp = new Item();
        try
        {
            //we first find the specific item by the items id
            temp = ORM.Items.Find(ID);
            ORM.Items.Remove(temp);
            ORM.SaveChanges();
            DeleteCustomerTransaction.Commit();
            //if the remove was successful we commit the transaction
            ViewBag.Message = $"{temp.Description} was removed";
        }
        catch (Exception ex)
        {
            //if the remove was unsuccessful then we 
            //roll back the transaction so no data is lost
            DeleteCustomerTransaction.Rollback();
            ViewBag.Message = "Item could not be removed";

            return View();
        }

        

        //this will go to my registration page
        //1.Link/2.ActionResult/3.View
        public ActionResult Registration()
        {
            
            // View();
        }

        public ActionResult Welcome(string first = "First", string last = "Last", int phone = 111-222-3333, string email = "email@whatever.com", 
                                    string password = "demc359", string country = "United States", int age = 11/22/1234)
        {
            //ActionResult
            ViewBag.data = first;
            ViewBag.last = last;
            ViewBag.phone = phone;
            ViewBag.email = email;
            ViewBag.password = password;
            ViewBag.country = country;
            ViewBag.birthday = age;
            return View();
        }
    }
}