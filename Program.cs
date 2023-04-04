using CardsAPI.Services;

namespace CardsAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            CardService cardService = new CardService();

            builder.Services.AddSingleton<ICardService>(cardService);

            builder.Services.AddGraphQLServer()
                    .AddQueryType(d => d.Name(OperationTypeNames.Query))
                    .AddType<Query>()
                    .AddSorting()
                    .InitializeOnStartup();


            var app = builder.Build();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });

            app.MapGraphQL();

            app.MapControllers();

            app.Run();
        }
    }
}