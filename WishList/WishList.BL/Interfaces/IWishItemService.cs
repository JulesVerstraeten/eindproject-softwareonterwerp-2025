using WishList.BL.Models;

namespace WishList.BL.Interfaces;

public interface IWishItemService
{
    Task<List<WishItemModel>> GetAllWishItemsAsync();
    Task<WishItemModel> GetWishItemByIdAsync(int id);
    Task<WishItemModel> SaveWishItemAsync(WishItemModel wishItem);
}