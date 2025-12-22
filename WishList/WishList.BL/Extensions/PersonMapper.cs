using WishList.BL.Models;
using WishList.DL.Entities;

namespace WishList.BL.Extensions;

public static class PersonMapper
{
    public PersonEntity AsEntity(PersonModel model)
    {
        return new PersonEntity
        {
            Id = model.Id ?? null,
            FirstName = model.FirstName,
            LastName = model.LastName,
        };
    }
}