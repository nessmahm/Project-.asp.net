using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP3.Models;
using System.Data.SQLite;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;

namespace TP3.Controllers
{

    public class PersonneController : Controller
    { 
        private readonly ILogger<PersonneController> _logger;
        Personal_Info personal_Info = new Personal_Info();

        public PersonneController(ILogger<PersonneController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            ViewBag.personnes = personal_Info.GetAllPerson();


            return View();
        }

        [HttpGet("/personne/personne/{id}")]
        public IActionResult Privacy(int id)
        {
            ViewBag.personne = personal_Info.GetPerson(id);

            return View();
        }


        [HttpGet("/personne/search")]
        public IActionResult Search()
        {

            return View();
        }

        [HttpPost("/personne/search")]
        public IActionResult Search(String Firstname, String Country)
        {

            return RedirectToAction ( "personne","personne", new { id = personal_Info.SearchPerson(Firstname, Country) });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}