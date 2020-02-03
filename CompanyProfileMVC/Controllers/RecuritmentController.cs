using CompanyProfileMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyProfileMVC.Controllers
{
    public class RecuritmentController : Controller
    {
        // GET: Recuritment
        CompanyProfileEntities database = new CompanyProfileEntities();
        public ActionResult ViewDetails()
        {
            return View(database.Recuritments.ToList());
        }

        // GET: Recuritment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Recuritment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recuritment/Create
        [HttpPost]
        public ActionResult Create(Recuritment recuritmentToAdd)
        {
            if (!ModelState.IsValid)
                return View();
            database.Recuritments.Add(recuritmentToAdd);
            database.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("ViewDetails");
        }

        // GET: Recuritment/Edit/5
        public ActionResult Edit(int id)
        {
            var JobToEdit = (from m in database.Recuritments where m.id == id select m).First();
            return View(JobToEdit);
        }

        // POST: Recuritment/Edit/5
        [HttpPost]
        public ActionResult Edit(Recuritment JobToEdit)
        {

            var orignalRecord = (from m in database.Recuritments where m.id == JobToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            database.Entry(orignalRecord).CurrentValues.SetValues(JobToEdit);

            database.SaveChanges();
            return RedirectToAction("ViewDetails");
        }

        // GET: Recuritment/Delete/5
        public ActionResult Delete(Recuritment JobToDelete)
        {
            var d = database.Recuritments.Where(x => x.id == JobToDelete.id).FirstOrDefault();
            database.Recuritments.Remove(d);
            database.SaveChanges();
            return RedirectToAction("ViewDetails");
        }

        // POST: Recuritment/Delete/5
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
