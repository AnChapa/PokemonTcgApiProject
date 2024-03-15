using Newtonsoft.Json;
using PokemonFinalProject.Models;
using PokemonFinalProject.Service;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonFinalProject.Service
{
    public class CardRetrieval
    {
        private readonly HttpClient _client;

        public CardRetrieval(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<List<Card>> GetCards()
        {
            var tcgApiURL = "https://api.pokemontcg.io/v2/cards?orderBy=name,-number";
            var tcgResponse = await _client.GetAsync(tcgApiURL);

            if (tcgResponse.IsSuccessStatusCode)
            {
                var responseContent = await tcgResponse.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<PokemonTCGApiResponse>(responseContent);

                return jsonResponse.Data;
            }
            else
            {
                Console.WriteLine($"Failed to fetch data. Status code: {tcgResponse.StatusCode}");
                return null;
            }
        }

        public async Task<Card> GetCardById(string id)
        {
            var tcgApiURL = $"https://api.pokemontcg.io/v2/cards/{id}";
            var tcgResponse = await _client.GetAsync(tcgApiURL);

            if (tcgResponse.IsSuccessStatusCode)
            {
                var responseContent = await tcgResponse.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<CardApiResponse>(responseContent);

                return jsonResponse.Card;
            }
            else
            {
                Console.WriteLine($"Failed to fetch data. Status code: {tcgResponse.StatusCode}");
                return null;
            }
        }

        public class CardApiResponse
        {
            [JsonProperty("data")]
            public Card Card { get; set; }
        }

        public class PokemonTCGApiResponse
        {
            [JsonProperty("data")]
            public List<Card> Data { get; set; }
        }
    }
}
