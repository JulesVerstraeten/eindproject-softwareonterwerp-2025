using WishList.BL.Models;

namespace WishList.BL.Interfaces;

public interface IChristmasItemService
{
    Task<List<ChristmasItemModel>> GetAllChristmasItemsAsync();
    Task<ChristmasItemModel> GetChristmasItemByIdAsync(int id);
    Task<ChristmasItemModel> SaveChristmasItemAsync(ChristmasItemModel item);
}