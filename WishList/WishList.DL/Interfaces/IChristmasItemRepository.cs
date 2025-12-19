using WishList.DL.Entities;

namespace WishList.DL.Interfaces;

public interface IChristmasItemRepository
{
    Task<List<ChristmasItemEntity>> GetAllChristmasItemsAsync();
    Task<ChristmasItemEntity>  GetChristmasItemByIdAsync(int christmasItemId);
    Task<ChristmasItemEntity> SaveChristmasItemAsync(ChristmasItemEntity itemEntity);
}