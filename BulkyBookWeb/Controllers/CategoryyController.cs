﻿using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryyController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CategoryyController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;

            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {


            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
