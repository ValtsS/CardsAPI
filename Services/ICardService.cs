using CardsAPI.Controllers;
using CardsAPI.Models;

namespace CardsAPI.Services
{
    public interface ICardService
    {
        public Task<Card[]> GetCardsAsync(CardFilter filter);
    }
}
