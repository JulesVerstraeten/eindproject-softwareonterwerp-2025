using WishList.DL.Entities;

namespace WishList.DL.Interfaces;

public interface IWishItemRepository
{
    Task<List<WishItemEntity>> GetAllWishItemAsync();
    Task<WishItemEntity> GetWishItemByIdAsync(int wishItemId);
    Task<WishItemEntity> SaveWishItemAsync(WishItemEntity wishItem);
}