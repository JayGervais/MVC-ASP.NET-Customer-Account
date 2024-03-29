﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelExperts_CPRG214_Final_JayGervais.Models;

namespace TravelExperts_CPRG214_Final_JayGervais.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details()
        {
            int id = Convert.ToInt32(Session["CustomerId"]);
            Customer customer = CustomerDB.CustomerDetails(id);
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer cust)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // add new user
                    CustomerDB.CreateAccount(cust);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit()
        {
            int id = Convert.ToInt32(Session["CustomerId"]);
            Customer currentCust = CustomerDB.CustomerDetails(id);
            return View(currentCust);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int id = Convert.ToInt32(Session["CustomerId"]);
                    CustomerDB.EditCustomer(id, customer);
                    return RedirectToAction("Details");
                }
                catch
                {
                    return View();
                }               
            }
            else
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
