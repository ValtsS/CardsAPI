using CardsAPI.Controllers;
using CardsAPI.Models;
using CardsAPI.Services;

namespace CardsAPI;


[ExtendObjectType(OperationTypeNames.Query)]
public sealed class Query
{

    [Serial]
    [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 50, MaxPageSize = 100)]
    [UseSorting]
    public async Task<Card[]> getCards([Service] ICardService service, CardFilter filter )
    {
        return await service.GetCardsAsync( filter );
    }


}
