﻿using Microsoft.AspNet.Identity.EntityFramework;
using PointOfSales.Custom_Filters;
using PointOfSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PointOfSales.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context;

        
        public RoleController()
        {
            context = new ApplicationDbContext();
        }



        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>

        [AuthLog(Roles = "02Management")]
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        /// <summary>
        /// Create  a New role
        /// </summary>
        /// <returns></returns>
        [AuthLog(Roles = "02Management")]
        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        /// <summary>
        /// Create a New Role
        /// </summary>
        /// <param name="Role"></param>
        /// <returns></returns>
        [HttpPost]

        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}