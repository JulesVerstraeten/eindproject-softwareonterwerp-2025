using SQLite;
using WishList.DL.Context;
using WishList.DL.Entities;
using WishList.DL.Exceptions;
using WishList.DL.Interfaces;

namespace WishList.DL.Repositories;

public class PersonRepository(WishlistDbContext context) : IPersonRepository
{
    private readonly SQLiteAsyncConnection _db = context.Connection;

    public async Task<List<PersonEntity>> GetAllPeopleAsync()
    {
        try
        {
            var entities = await _db.Table<PersonEntity>().ToListAsync();
            return entities;
        }
        catch (Exception e)
        {
            throw new RepositoryException("Error while fetching all people", e);
        }
    }

    public async Task<PersonEntity> GetPersonByIdAsync(int personId)
    {
        try
        {
            var entity = await _db.FindAsync<PersonEntity>(personId);
            if (entity == null)
                throw new KeyNotFoundException($"Person with Id {personId} not found.");
            return entity;
        }
        catch (Exception e)
        {
            throw new RepositoryException("Error while fetching person by id", e);
        }
    }

    public async Task<PersonEntity> SavePersonAsync(PersonEntity person)
    {
        try
        {
            if (person.Id == 0)
            {
                await _db.InsertAsync(person);
            }
            else
            {
                await _db.UpdateAsync(person);
            }

            return person;
        }
        catch (Exception e)
        {
            throw new RepositoryException("Error while saving person", e);
        }
    }
}