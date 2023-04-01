using CardsAPI.Models;
using CardsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CardsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController : ControllerBase
    {

        private readonly ILogger<CardsController> _logger;
        private readonly ICardService service;

        public CardsController(ILogger<CardsController> logger, ICardService cardService)
        {
            _logger = logger;
            service = cardService;
        }

        [HttpGet]
        public async Task<Card[]> Get(string? query)
        {
            return await service.GetCardsAsync(new CardFilter() { searchQuery = query ?? "" });
        }
    }
}