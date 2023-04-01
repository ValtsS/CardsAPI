namespace CardsAPI.Models
{
    [GraphQLName("Card")]
    public class Card
    {
        public string uuid { get; set; }
        public string title { get; set; }
        public string imageUrl { get; set; }
        public string text { get; set; }
        public string price { get; set; }
        public DateTime? addedat { get; set; }
        public string minipic { get; set; }
        public int? rating { get; set; }
        public bool flipimg { get; set; }
        public bool grayscale { get; set; }

        public bool Matches(string query)
        {
            if (string.IsNullOrEmpty(query)) return true;

            return (price.Contains(query) ||
                text.Contains(query) ||
                title.Contains(query) ||
                ((addedat.HasValue) && addedat.Value.ToString().Contains(query))
                );

        }

    }
}
