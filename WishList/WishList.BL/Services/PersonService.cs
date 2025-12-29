using WishList.BL.Exceptions;
using WishList.BL.Extensions;
using WishList.BL.Interfaces;
using WishList.BL.Models;
using WishList.DL.Interfaces;

namespace WishList.BL.Services;

public class PersonService(IPersonRepository personRepository): IPersonService
{
    public async Task<List<PersonModel>> GetAllPersonsAsync()
    {
        try
        {
            var entities = await personRepository.GetAllPeopleAsync();
            var models = entities.Select(PersonMapper.AsModel).ToList();
            return models;
        }
        catch (Exception ex)
        {
            throw new ServiceException("Error while retrieving all persons", ex);
        }
    }

    public async Task<PersonModel> GetPersonByIdAsync(int personId)
    {
        try
        {
            var entity = await personRepository.GetPersonByIdAsync(personId);
            if (entity == null) throw new Exception("Entity not found");
            return entity.AsModel();
        }
        catch (Exception ex)
        {
            throw new ServiceException("Error while retrieving person by ID", ex);
        }
    }

    public async Task<PersonModel> SavePersonAsync(PersonModel person)
    {
        try
        {
            var entity = person.AsEntity();
            await personRepository.SavePersonAsync(entity);
            return entity.AsModel();
        }
        catch (Exception ex)
        {
            throw new ServiceException("Error while saving person", ex);
        }
    }
}