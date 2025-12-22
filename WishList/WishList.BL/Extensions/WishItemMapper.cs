using WishList.BL.Models;
using WishList.DL.Entities;

namespace WishList.BL.Extensions;

public static class WishItemMapper
{
    public static WishItemEntity ToEntity(this WishItemModel model)
    {
        return new WishItemEntity
        {
            Id = model.Id ?? 0,
            Title = model.Title,
            Description = model.Description,
            PictureUrl = model.PictureUrl,
            WebsiteUrl = model.WebsiteUrl
        };
    }

    public static WishItemModel ToModel(this WishItemEntity entity)
    {
        return new WishItemModel
        {
            Id = entity.Id,
            Title = entity.Title,
            WebsiteUrl = entity.WebsiteUrl,
            PictureUrl = entity.PictureUrl,
            Description = entity.Description,
        };
    }
}