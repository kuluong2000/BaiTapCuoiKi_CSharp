﻿using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        // GET: User/Home
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            var categoryDao = new CategoryDao();
            ViewBag.NewProducts = productDao.ListNewProduct(9);
            ViewBag.ListFeatureProducts = productDao.ListFeatureProduct(9);
            ViewBag.NewCategorys= categoryDao.ListNewCate(10);
           
            return View();
        }

    }
}