using System;
using System.Collections.Generic;
using System.Linq;

namespace CardsAPI.Models;

public class TextGenerator
{
    private readonly Random _random;

    private readonly string[] _verbs = { "book", "reserve", "select", "choose", "get", "find" };
    private readonly string[] _nouns = { "room", "suite", "bed", "pillow", "view", "balcony", "bathroom", "shower", "tub", "amenities", "hotel", "reservation", "guests", "booking" };
    private readonly string[] _adjectives = { "luxurious", "cozy", "spacious", "comfortable", "modern", "elegant", "stylish", "sleek", "clean", "affordable", "beautiful" };

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

        return $"{string.Join(" ", adjectives)} {string.Join(" ", nouns)} - Book now at our top-rated hotel!";
    }
}
