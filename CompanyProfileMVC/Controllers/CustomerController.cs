using CompanyProfileMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyProfileMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        CompanyProfileEntities database = new CompanyProfileEntities();

        public ActionResult ViewDetails()
        {
            return View(database.Customers.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Customer CustomerToAdd)
        {
            if (!ModelState.IsValid)
                return View();
            database.Customers.Add(CustomerToAdd);
            database.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("ViewDetails");
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            var CustomerToEdit = (from m in database.Customers where m.id == id select m).First();
            return View(CustomerToEdit);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer CustomerToEdit)
        {

            var orignalRecord = (from m in database.Customers where m.id == CustomerToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            database.Entry(orignalRecord).CurrentValues.SetValues(CustomerToEdit);

            database.SaveChanges();
            return RedirectToAction("ViewDetails");
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(Customer CustomerToDelete)
        {
            var d = database.Customers.Where(x => x.id == CustomerToDelete.id).FirstOrDefault();
            database.Customers.Remove(d);
            database.SaveChanges();
            return RedirectToAction("ViewDetails");
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
