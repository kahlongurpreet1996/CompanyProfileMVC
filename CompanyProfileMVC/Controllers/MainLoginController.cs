using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyProfileMVC.Models;
using System.Data;
using System.Data.SqlClient;

namespace CompanyProfileMVC.Controllers
{
    public class MainLoginController : Controller
    {
        // GET: MainLogin
        public ActionResult MainLogin()
        {
            return View();
        }

        public ActionResult Login(MainLogin data)
        {

            DataTable tbl = new DataTable();

            MainLogin obj_connection = new MainLogin();

            tbl = obj_connection.srchRecord("Select * from AdminDetails where AdminId='" + data.AdminId + "' and AdminPin='" + data.AdminPin + "'");
            if (tbl.Rows.Count > 0)
            {
                return View("AdminZone");
            }
            else
            {
                return View("Invalid");
            }


        }


    }
}