namespace CardsAPI.Controllers
{
    [GraphQLName("CardFilterInput")]
    public class CardFilter
    {
        public string searchQuery { get; set; }
        public string uuid { get;set; }

    }
}
