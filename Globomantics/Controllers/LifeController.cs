﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Models;
using Globomantics.Services;
using Microsoft.Extensions.Logging;

namespace Globomantics.Controllers
{
    public class LifeController : Controller
    {
        private ILogger<LifeController> logger;
        private IQuoteService quoteService;

        public LifeController(IQuoteService quoteService, ILogger<LifeController> logger)
        {
            this.logger = logger;
            this.quoteService = quoteService;
        }

        public IActionResult Quote()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Quote(LifeQuote quote)
        {
            return RedirectToAction("Confirmation", "Insurance");
        }
    }
}
