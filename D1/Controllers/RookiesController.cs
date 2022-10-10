using D1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace D1.Controllers
{
    public class RookiesController : Controller
    {
        private static List<PersonModel> _people = new List<PersonModel>
        {
            new PersonModel
            {
                FirstName = "Linh",
                LastName = "Le Tuan",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 12, 15),
                PhoneNumber ="",
                BirthPlace = "Phu Tho",
                IsGraduated = false
            },
              new PersonModel
            {
                FirstName = "Linh",
                LastName = "Tran Tuan",
                Gender = "Female",
                DateOfBirth = new DateTime(2002, 12, 15),
                PhoneNumber ="",
                BirthPlace = "Ha Noi",
                IsGraduated = true
            },
                new PersonModel
            {
                FirstName = "Long",
                LastName = "Le Tuan",
                Gender = "Male",
                DateOfBirth = new DateTime(2003, 12, 15),
                PhoneNumber ="",
                BirthPlace = "HCM",
                IsGraduated = false
            },
                  new PersonModel
            {
                FirstName = "Linh",
                LastName = "Le Van",
                Gender = "Male",
                DateOfBirth = new DateTime(2004, 12, 15),
                PhoneNumber ="",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
        };
        private readonly ILogger<RookiesController> _logger;
        public RookiesController(ILogger<RookiesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {      
            return Json(_people);
        }

        public IActionResult GetMaleMembers()
        {
            var data = _people.Where(p => p.Gender == "Male");
            return Json(data);
        }

        public IActionResult GetOldestMember()
        {
            var maxAge = _people.Max(p => p.Age);
            var oldest = _people.FirstOrDefault(p => p.Age == maxAge);
            return Json(oldest);
        }

        public IActionResult GetFullNames()
        {
            var fullNames = _people.Select(p => p.FullName);
            return Json(fullNames);
        }

        private IActionResult GetMembersByBirthYear(int year, string compareType)
        {
            switch (compareType)
            {
                case "equals":
                    return Json(_people.Where(p => p.DateOfBirth?.Year == year));
                case "greaterThan":
                    return Json(_people.Where(p => p.DateOfBirth?.Year > year));
                case "lessThan":
                    return Json(_people.Where(p => p.DateOfBirth?.Year < year));
                default:
                    return Json(null);
            }
        }

        public IActionResult GetMembersWhoBornIn2000()
        {
            return RedirectToAction("GetMembersByBirthYear", new { year = 2000, compareType = "equal" });
        }

        public IActionResult GetMembersWhoBornAfter2000()
        {
            return RedirectToAction("GetMembersByBirthYear", new { year = 2000, compareType = "greaterThan" });
        }

        public IActionResult GetMembersWhoBornBefore2000()
        {
            return RedirectToAction("GetMembersByBirthYear", new { year = 2000, compareType = "lessThan" });
        }
    };
}
