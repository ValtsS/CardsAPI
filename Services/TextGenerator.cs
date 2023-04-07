using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsAPI.Models;

public class TextGenerator
{
    private readonly Random _random;

    private readonly string[] _verbs = { "book", "reserve", "select", "choose", "get", "find", "explore", "browse", "view", "check", "compare", "search", "request", "confirm", "modify", "update", "pay", "review", "rate", "recommend" };
    private readonly string[] _nouns = { "room", "suite", "bed", "pillow", "view", "balcony", "bathroom", "shower", "tub", "amenities", "hotel", "reservation", "guests", "booking", "check-in", "check-out", "lobby", "restaurant", "bar", "pool", "gym", "conference", "business", "wifi" };
    private readonly string[] _adjectives = { "luxurious", "cozy", "spacious", "comfortable", "modern", "elegant", "stylish", "sleek", "clean", "affordable", "beautiful", "chic", "romantic", "relaxing", "secluded", "scenic", "quaint", "historic", "charming", "resort-like", "family-friendly", "pet-friendly", "accessible", "unique" };


    public TextGenerator(int seed)
    {
        _random = new Random(seed);
    }

    private string GetRandomWord(string[] words)
    {
        return words[_random.Next(words.Length)];
    }

    public string GenerateText()
    {
        var verbs = Enumerable.Range(1, _random.Next(1, 3)).Select(i => GetRandomWord(_verbs));
        var nouns = Enumerable.Range(1, _random.Next(1, 5)).Select(i => GetRandomWord(_nouns));
        var adjectives = Enumerable.Range(1, _random.Next(1, 3)).Select(i => GetRandomWord(_adjectives));

        return $"Looking to {string.Join(" ", verbs)} a {string.Join(" ", adjectives)} {string.Join(" ", nouns)}? Look no further than our top-rated hotel!";
    }

    public string GenerateTitle()
    {
        var adjectives = Enumerable.Range(1, _random.Next(1, 3)).Select(i => GetRandomWord(_adjectives));
        var nouns = Enumerable.Range(1, _random.Next(1, 5)).Select(i => GetRandomWord(_nouns));

        string title = $"{string.Join(" ", adjectives)} {string.Join(" ", nouns)} - Book now at our top-rated hotel!";
        return char.ToUpper(title[0]) + title.Substring(1);
    }
}
