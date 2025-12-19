using SQLite;
using WishList.DL.Entities;
using WishList.DL.Interfaces;

namespace WishList.DL.Repositories;

public class ChristmasItemRepository(WishlistDbContext context) : IChristmasItemRepository
{
    private readonly SQLiteAsyncConnection _db = context.Connection;
    
    public async Task<List<ChristmasItemEntity>> GetAllChristmasItemsAsync()
    {
        try
        {
            var entities = await _db.Table<ChristmasItemEntity>().ToListAsync();
            return entities;
        }
        catch (Exception e)
        {
            throw new Exception($"ChristmasItemRepository: {e.Message}");
        }
    }

    public async Task<ChristmasItemEntity> GetChristmasItemByIdAsync(int christmasItemId)
    {
        try
        {
            var entity =  await _db.FindAsync<ChristmasItemEntity>(christmasItemId);
            return entity;
        }
        catch (Exception e)
        {
            throw new Exception($"ChristmasItemRepository: {e.Message}");
        }
    }

    public async Task<ChristmasItemEntity> SaveChristmasItemAsync(ChristmasItemEntity itemEntity)
    {
        try
        {
            if (itemEntity == null || itemEntity.Id == 0)
            {
                await _db.InsertAsync(itemEntity);
            }
            else
            {
                await _db.UpdateAsync(itemEntity);
            }
            
            return itemEntity;
        }
        catch (Exception e)
        {
            throw new Exception($"ChristmasItemRepository: {e.Message}");
        }
    }
}