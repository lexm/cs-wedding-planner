using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using wplan.Models;

namespace wplan.Controllers
{
    public class WeddingController : Controller
    {
        private WPlanContext _context;

        public WeddingController(WPlanContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("plan")]
        public IActionResult Plan()
        {
            return View();
        }

        [HttpPost]
        [Route("plan")]
        public IActionResult SetPlan(WeddingViewModel plan)
        {
            if (ModelState.IsValid)
            {
                System.Console.WriteLine("wed1: {0}", plan.wedder1);
                System.Console.WriteLine("wed2: {0}", plan.wedder2);
                System.Console.WriteLine("date: {0}", plan.date);
                System.Console.WriteLine("address: {0}", plan.address);
                if(plan.date > DateTime.Now)
                {
                    Wedding NewWedding = new Wedding
                    {
                        wedder1 = plan.wedder1,
                        wedder2 = plan.wedder2,
                        date = plan.date,
                        address = plan.address,
                        created_at = DateTime.Now,
                        updated_at = DateTime.Now
                    };
                    _context.Add(NewWedding);
                    _context.SaveChanges();
                    return RedirectToAction("Success", "User");
                }
                else
                {
                    ModelState.AddModelError("date", "Date must be in the future");
                    ViewBag.errors = ModelState.Values;
                    return View("~/Views/Wedding/Plan.cshtml", plan);
                }
            }
            else
            {
                System.Console.WriteLine("Iz nah guud.");
                return View("~/Views/Wedding/Plan.cshtml", plan);
            }
        }
    }
}