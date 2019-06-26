using System;
using Globomantics.Filters;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Models;
using Globomantics.Services;

namespace Globomantics.Controllers
{
    [TypeFilter(typeof(FeatureAuthFilter), Arguments = new object[] { "Loan" })]
    public class LoanController : Controller
    {
        private readonly ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {
            this._loanService = loanService;
        }

        public IActionResult Application()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Application(LoanDetails app)
        {
            if (ModelState.IsValid)
            {
                _loanService.CreateLoanApplication(app, Guid.NewGuid().ToString());
                return RedirectToAction("Employment");
            }

            return View(app);
        }

        [HttpGet]
        public IActionResult Employment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Employment(Employment employment)
        {
            _loanService.UpdateLoanEmployment(employment);
            return RedirectToAction("Personal");
        }

        [HttpGet]
        public IActionResult Personal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Personal(Person person)
        {
            _loanService.UpdateLoanPersonalInfo(person);
            return RedirectToAction("Confirmation");
        }

        [HttpGet]
        public IActionResult Confirmation()
        {
            var loan = _loanService.GetConfirmationDetails();
            return View(loan);
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
    }
}
