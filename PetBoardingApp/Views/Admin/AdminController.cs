﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetBoardingApp.Views.Admin
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pets()
        {
            return View();
        }
        public ActionResult Bookings()
        {
            return View();
        }
    }
}