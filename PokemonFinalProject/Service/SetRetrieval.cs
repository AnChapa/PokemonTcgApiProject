using Newtonsoft.Json;
using PokemonFinalProject.Models;

namespace PokemonFinalProject.Service
{
    public class SetRetrieval
    {
        private readonly HttpClient _client;

        public SetRetrieval(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<List<Set>> GetSets()
        {
            var tcgApiURL = "https://api.pokemontcg.io/v2/sets?orderBy=-set.releaseDate";
            var tcgResponse = await _client.GetAsync(tcgApiURL);

            if (tcgResponse.IsSuccessStatusCode)
            {
                var responseContent = await tcgResponse.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<PokemonTCGApiResponseSet>(responseContent);

                return jsonResponse.Data;
            }
            else
            {
                Console.WriteLine($"Failed to fetch data. Status code: {tcgResponse.StatusCode}");
                return null;
            }
        }

        public async Task<List<Card>> GetSetById(string id)
        {
            var tcgApiURL = $"https://api.pokemontcg.io/v2/cards/?q=set.id:{id}";
            var tcgResponse = await _client.GetAsync(tcgApiURL);

            if (tcgResponse.IsSuccessStatusCode)
            {
                var responseContent = await tcgResponse.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<CardApiResponseSet>(responseContent);

                return jsonResponse.Data;
            }
            else
            {
                Console.WriteLine($"Failed to fetch data. Status code: {tcgResponse.StatusCode}");
                return null;
            }
        }

        public class CardApiResponseSet
        {
            [JsonProperty("data")]
            public List<Card> Data { get; set; }
        }

        public class PokemonTCGApiResponseSet
        {
            [JsonProperty("data")]
            public List<Set> Data { get; set; }
        }
    }
}
