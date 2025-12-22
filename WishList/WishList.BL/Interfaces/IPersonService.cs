using WishList.BL.Models;

namespace WishList.BL.Interfaces;

public interface IPersonService
{
    Task<List<PersonModel>> GetAllPersonsAsync();
    Task<List<PersonModel>> GetPersonByIdAsync(int personId);
    Task<PersonModel> SavePersonAsync(PersonModel person);
}