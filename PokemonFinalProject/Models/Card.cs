using System;
using System.Collections.Generic;

namespace PokemonFinalProject.Models
{
    public class Card
    {
        public string id { get; set; }
        public string name { get; set; }
        public string supertype { get; set; }
        public List<string> subtypes { get; set; }
        public string hp { get; set; }
        public List<string> types { get; set; }
        public string evolvesFrom { get; set; }
        public List<Ability> abilities { get; set; }
        public List<Attack> attacks { get; set; }
        public List<Weakness> weaknesses { get; set; }
        public List<string> retreatCost { get; set; }
        public int convertedRetreatCost { get; set; }
        public Set set { get; set; }
        public string number { get; set; }
        public string artist { get; set; }
        public string rarity { get; set; }
        public string flavorText { get; set; }
        public List<int> nationalPokedexNumbers { get; set; }
        public Legalities legalities { get; set; }
        public Images images { get; set; }
        public TcgPlayer tcgPlayer { get; set; }
        public CardMarket cardMarket { get; set; }

        public Card()
        {
        }
    }

    public class Ability
    {
        public string name { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Attack
    {
        public string name { get; set; }
        public List<string> cost { get; set; }
        public int convertedEnergyCost { get; set; }
        public string damage { get; set; }
        public string text { get; set; }
    }

    public class Weakness
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    //public class Set
    //{
    //    public string id { get; set; }
    //    public string name { get; set; }
    //    public string series { get; set; }
    //    public int printedTotal { get; set; }
    //    public int total { get; set; }
    //    public Legalities legalities { get; set; }
    //    public string ptcgoCode { get; set; }
    //    public string releaseDate { get; set; }
    //    public string updatedAt { get; set; }
    //    public Images images { get; set; }

    //    public Set()
    //    {
    //    }

    //}

    public class Legalities
    {
        public string unlimited { get; set; }
        public string standard { get; set; }
        public string expanded { get; set; }
    }

    public class Images
    {
        public string symbol { get; set; }
        public string logo { get; set; }
        public string small { get; set; }
        public string large { get; set; }
    }

    public class TcgPlayer
    {
        public string url { get; set; }
        public string updatedAt { get; set; }
        public Prices prices { get; set; }
    }

    public class CardMarket
    {
        public string url { get; set; }
        public string updatedAt { get; set; }
        public Prices prices { get; set; }
    }

    public class Prices
    {
        public double? averageSellPrice { get; set; }
        public double? lowPrice { get; set; }
        public double? trendPrice { get; set; }
        public double? germanProLow { get; set; }
        public double? suggestedPrice { get; set; }
        public double? reverseHoloSell { get; set; }
        public double? reverseHoloLow { get; set; }
        public double? reverseHoloTrend { get; set; }
        public double? lowPriceExPlus { get; set; }
        public double? avg1 { get; set; }
        public double? avg7 { get; set; }
        public double? avg30 { get; set; }
        public double? reverseHoloAvg1 { get; set; }
        public double? reverseHoloAvg7 { get; set; }
        public double? reverseHoloAvg30 { get; set; }
    }
}
