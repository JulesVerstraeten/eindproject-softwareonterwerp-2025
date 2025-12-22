using WishList.BL.Models;
using WishList.DL.Entities;

namespace WishList.BL.Extensions;

public static class PersonMapper
{
    public static PersonEntity AsEntity(this PersonModel model)
    {
        return new PersonEntity
        {
            Id = model.Id ?? 0,
            FirstName = model.FirstName,
            LastName = model.LastName ?? string.Empty,
        };
    }

    public static PersonModel AsModel(this PersonEntity entity)
    {
        return new PersonModel
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
        };
    }
}