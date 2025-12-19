using WishList.DL.Entities;

namespace WishList.DL.Interfaces;

public interface IPersonRepository
{
    Task<List<PersonEntity>> GetAllPeopleAsync();
    Task<PersonEntity> GetPersonByIdAsync(int personId);
    Task<PersonEntity> SavePersonAsync(PersonEntity person);
}