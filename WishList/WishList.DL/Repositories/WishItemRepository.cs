using SQLite;
using WishList.DL.Context;
using WishList.DL.Entities;
using WishList.DL.Interfaces;

namespace WishList.DL.Repositories;

public class WishItemRepository(WishlistDbContext context) : IWishItemRepository
{
    private readonly SQLiteAsyncConnection _db = context.Connection;

    public async Task<List<WishItemEntity>> GetAllWishItemAsync()
    {
        try
        {
            var entities = await _db.Table<WishItemEntity>().ToListAsync();
            return entities;
        }
        catch (Exception e)
        {
            throw new Exception($"WishItemRepository: {e.Message}");
        }
    }

    public async Task<WishItemEntity> GetWishItemByIdAsync(int wishItemId)
    {
        try
        {
            var entity = _db.FindAsync<WishItemEntity>(wishItemId);
            return await entity;
        }
        catch (Exception e)
        {
            throw new Exception($"WishItemRepository: {e.Message}");
        }
    }

    public async Task<WishItemEntity> SaveWishItemAsync(WishItemEntity wishItem)
    {
        try
        {
            if (wishItem == null || wishItem.Id == 0)
            {
                await _db.InsertAsync(wishItem);
            }
            else
            {
                await _db.UpdateAsync(wishItem);
            }

            return wishItem;
        }
        catch (Exception e)
        {
            throw new Exception($"WishItemRepository: {e.Message}");
        }
    }
}