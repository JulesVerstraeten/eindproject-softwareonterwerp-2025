using System.Diagnostics;
using SQLite;
using WishList.DL.Context;
using WishList.DL.Entities;
using WishList.DL.Exceptions;
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
            var personsId = entities
                .Where(i => i.ForPersonId is > 0)
                .Select(i => i.ForPersonId!.Value)
                .Distinct()
                .ToList();
            var personEntities = await _db.Table<PersonEntity>()
                .Where(p => personsId.Contains(p.Id))
                .ToListAsync();
            var personDict = personEntities.ToDictionary(p => p.Id);

            foreach (var entity in entities)
            {
                if (entity.ForPersonId is > 0 && 
                    personDict.TryGetValue(entity.ForPersonId.Value, out var person))
                {
                    entity.ForPerson = person;
                }
            }
            
            return entities;
        }
        catch (Exception e)
        {
            throw new RepositoryException("Error fetching all ChristmasItems", e);
        }
    }

    public async Task<ChristmasItemEntity> GetChristmasItemByIdAsync(int christmasItemId)
    {
        try
        {
            var entity =  await _db.FindAsync<ChristmasItemEntity>(christmasItemId);
            if (entity.ForPersonId is > 0)
            {
                entity.ForPerson = await _db.GetAsync<PersonEntity>(entity.ForPersonId);
            }
            return entity;
        }
        catch (Exception e)
        {
            throw new RepositoryException("Error fetching ChristmasItem by ID", e);
        }
    }

    public async Task<ChristmasItemEntity> SaveChristmasItemAsync(ChristmasItemEntity itemEntity)
    {
        try
        {
            if (itemEntity.Id == 0)
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
            throw new RepositoryException("Error saving ChristmasItem", e);
        }
    }
}