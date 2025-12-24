using WishList.BL.Models;
using WishList.Maui.Models;

namespace WishList.Maui.Extensions;

public static class WishItemMapper
{
    public static WishItemViewModel AsViewModel(this WishItemModel model)
    {
        return new WishItemViewModel
        {
            Id = model.Id ?? 0,
            PictureUrl = model.PictureUrl,
            Title = model.Title,
            WebsiteUrl = model.WebsiteUrl,
            Description = model.Description,
        };
    }

    public static WishItemModel AsModel(this WishItemViewModel viewModel)
    {
        return new WishItemModel
        {
            Id = viewModel.Id,
            Title = viewModel.Title,
            WebsiteUrl = viewModel.WebsiteUrl,
            PictureUrl = viewModel.PictureUrl,
            Description = viewModel.Description,
        };
    }
}