﻿using AdminPage.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdminPage.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            string jsonData = System.IO.File.ReadAllText("categoryJson.json");
            var model = JsonConvert.DeserializeObject<List<Category>>(jsonData);
            ViewBag.Categories = model;
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult AddNew(string title, string description, IFormFile image, IFormFile content, bool status, string releaseDate)
        {
            return View("Create");
        }
        public IActionResult Detail(int id)
        {
            return View();
        }
        public IActionResult Update()
        {
            return View("Detail");
        }
        public IActionResult Delete(int id)
        {
            string jsonData = System.IO.File.ReadAllText("myJson.json");
            var model = JsonConvert.DeserializeObject<List<Book>>(jsonData);
            ViewBag.Books = model;
            return View("Index");
        }
    }
}
