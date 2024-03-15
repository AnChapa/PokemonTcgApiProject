using Microsoft.AspNetCore.Mvc;
using PokemonFinalProject.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using PokemonFinalProject.Service;

namespace PokemonFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly SetRetrieval _setRet;

        public HomeController(SetRetrieval setRetrieval)
        {
            _setRet = setRetrieval;
        }

        public async Task<IActionResult> SetView()
        {
            List<Set> sets = await _setRet.GetSets();
            if (sets != null)
            {
                return View(sets);
            }
            else
            {
                return View("Error");
            }
        }
        public async Task<IActionResult> SetDetails(string id)
        {
            // Fetch the card with the specified ID from your data source
            // For now, let's assume you have a method in CardService to retrieve a single card by ID
            var set = await _setRet.GetSetById(id);

            if (set == null)
            {
                return NotFound(); // Return a 404 Not Found error if the card is not found
            }

            return View(set); // Return the card details view with the card model
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
