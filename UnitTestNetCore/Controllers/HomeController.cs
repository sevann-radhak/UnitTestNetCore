﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnitTestNetCore.Models;
using UnitTestNetCore.Services;

namespace UnitTestNetCore.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IPersonService _personService;

        public HomeController(
            //ILogger<HomeController> logger,
            IPersonService personService)
        {
            //_logger = logger;
            _personService = personService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public ViewResult CreatePerson(Person person)
        {
            if(!_personService.IsValid(person))
            {
                ViewData["MessageError"] = "Error";
                ViewBag.MessageError = "Error";
                return View();
            }
            return View();
        }
    }
}
