using WishList.BL.Models;
using WishList.DL.Entities;

namespace WishList.BL.Extensions;

public static class ChristmasItemMapper
{
    public static ChristmasItemEntity AsEntity(this ChristmasItemModel model)
    {
        return new ChristmasItemEntity
        {
            Id = model.Id ?? 0,
            PictureUrl = model.PictureUrl,
            Title = model.Title,
            WebsiteUrl = model.WebsiteUrl,
            Description = model.Description,
            Price = model.Price,
            ForPersonId = model.ForPersonId,
            ForPerson = model.ForPerson?.AsEntity()
        };
    }

    public static ChristmasItemModel AsModel(this ChristmasItemEntity entity)
    {
        return new ChristmasItemModel
        {
            Id = entity.Id,
            Title = entity.Title,
            WebsiteUrl = entity.WebsiteUrl,
            PictureUrl = entity.PictureUrl,
            Description = entity.Description,
            Price = entity.Price,
            ForPersonId = entity.ForPersonId,
            ForPerson = entity.ForPerson?.AsModel()
        };

    }
}