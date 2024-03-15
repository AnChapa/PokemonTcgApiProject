namespace PokemonFinalProject.Models
{
    public class Set
    {
        public string id { get; set; }
        public string name { get; set; }
        public string series { get; set; }
        public int printedTotal { get; set; }
        public int total { get; set; }
        public Legalities legalities { get; set; }
        public string ptcgoCode { get; set; }
        public DateTime releaseDate { get; set; }
        public DateTime updatedAt { get; set; }
        public Images images { get; set; }

        public Set()
        {

        }
    }

}
