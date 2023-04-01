using CardsAPI.Controllers;
using CardsAPI.Models;

namespace CardsAPI.Services
{
    public class CardService : ICardService
    {
        const int cardCount = 1000;
        List<Card> cards = new();

        public CardService() {

            var gen = new DummyCards();
            for (int i = 0; i < cardCount; i++)
                cards.Add(gen.cook());


        }

        public async Task<Card[]> GetCardsAsync(CardFilter filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            return this.cards.Where(a =>
                a.Matches(filter.searchQuery)
            ).ToArray();
        }
    }
}
