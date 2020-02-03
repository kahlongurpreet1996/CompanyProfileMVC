using CompanyProfileMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyProfileMVC.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        CompanyProfileEntities database = new CompanyProfileEntities();
        public ActionResult ViewDetails()
        {
            return View(database.Staffs.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]Staff StaffToAdd)
        {

            if (!ModelState.IsValid)
                return View();
            database.Staffs.Add(StaffToAdd);
            database.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("ViewDetails");
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            var StaffToEdit = (from m in database.Staffs where m.id == id select m).First();
            return View(StaffToEdit);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(Staff StaffToEdit)
        {

            var orignalRecord = (from m in database.Staffs where m.id == StaffToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            database.Entry(orignalRecord).CurrentValues.SetValues(StaffToEdit);

            database.SaveChanges();
            return RedirectToAction("ViewDetails");
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(Staff StaffToDelete)
        {
            var d = database.Staffs.Where(x => x.id == StaffToDelete.id).FirstOrDefault();
            database.Staffs.Remove(d);
            database.SaveChanges();
            return RedirectToAction("ViewDetails");
            
        }

        // POST: Staff/Delete/5
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
