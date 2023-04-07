using CardsAPI.Models;

namespace CardsAPI.Services
{
    public class DummyCards
    {
        private Random seq = new Random(1234);

        private int Next()
        {
            return seq.Next(999999999);
        }

        private DateTime rndDate(int id)
        {
            id = id % 180;
            return new DateTime(2022, 4, 1).AddDays(-Math.Abs(id));
        }

        string[] dummypics = new string[] {
    "https://randomwordgenerator.com/img/picture-generator/54e3d3474c5aa514f1dc8460962e33791c3ad6e04e507440772d73d79749c7_640.jpg",
    "https://randomwordgenerator.com/img/picture-generator/55e8d3454d51b10ff3d8992cc12c30771037dbf85254794e722a73d4944b_640.jpg",
    "https://randomwordgenerator.com/img/picture-generator/giraffe-3351363_640.jpg",
    "https://randomwordgenerator.com/img/picture-generator/53e7d24b4d55ab14f1dc8460962e33791c3ad6e04e5077497c2a7ddd9e4dcd_640.jpg",
    "https://randomwordgenerator.com/img/picture-generator/57e1d24b4352a914f1dc8460962e33791c3ad6e04e507440752f78d09445c6_640.jpg"
};

        string[] minipic = new string[] {
    "https://randompicturegenerator.com/img/cat-generator/g0f94542dc316be8269f644259b2c33352d35679ae6abdefb768f6dc1e5ca62034d4dab3a649ebf74bd6997fd4fa16fa4_640.jpg",
    "https://randompicturegenerator.com/img/cat-generator/gbc0167b5494b0f694cef1a200e0c580556048963590ce82c252451d73dfcdd9ed9ff28282a16b8f901f409deaa7a54e8_640.jpg",
    "https://randompicturegenerator.com/img/cat-generator/ge9db644b010d046c9a4c2f01e132948959134b9b409680e72b3d758f7da3f8667c637f23a3e8984870b2aeb982859983_640.jpg",
    "https://randompicturegenerator.com/img/cat-generator/g5d735248ebee4eacce077a3a5d0c832a7b306cb0edc1c28944edc9b44caea6e794b0b0ba00bbb22c55f24e819bb4ae12_640.jpg"
};


        public Card cook()
        {
            var id = Next();
            var gen = new TextGenerator(id);

            return new Card
            {
                uuid = id.ToString(),
                title = gen.GenerateTitle(),
                imageUrl = dummypics[id % dummypics.Length],
                text = gen.GenerateText(),
                price = Math.Abs(id % 3000),
                addedat = rndDate(id),
                minipic = minipic[id % minipic.Length],
                rating = 1 + Math.Abs(id) % 4,
                grayscale = id % 3 == 0,
                flipimg = id % 4 == 0

            };


        }
    }
}
