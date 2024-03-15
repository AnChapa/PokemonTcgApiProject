using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PokemonFinalProject.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using PokemonFinalProject.Service;

namespace PokemonFinalProject.Controllers
{
    public class PokemonAPIController : Controller
    {
        private readonly CardRetrieval _cardRet;

        public PokemonAPIController(CardRetrieval cardRet)
        {
            _cardRet = cardRet;
        }

        public async Task<IActionResult> CardView()
        {
            List<Card> cards = await _cardRet.GetCards();
            if (cards != null)
            {
                return View(cards);
            }
            else
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> CardDetails(string id)
        {
            // Fetch the card with the specified ID from your data source
            // For now, let's assume you have a method in CardService to retrieve a single card by ID
            var card = await _cardRet.GetCardById(id);

            if (card == null)
            {
                return NotFound(); // Return a 404 Not Found error if the card is not found
            }

            return View(card); // Return the card details view with the card model
        }

    }

}
