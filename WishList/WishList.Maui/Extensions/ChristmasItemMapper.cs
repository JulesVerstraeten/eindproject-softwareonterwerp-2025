using WishList.BL.Models;
using WishList.Maui.Models;

namespace WishList.Maui.Extensions;

public static class ChristmasItemMapper
{
    public static ChristmasItemViewModel AsViewModel(this ChristmasItemModel model)
    {
        return new ChristmasItemViewModel
        {
            Id = model.Id,
            PictureUrl = model.PictureUrl,
            Title = model.Title,
            WebsiteUrl = model.WebsiteUrl,
            Description = model.Description,
            ForPerson = model.ForPerson != null ? new PersonViewModel
            {
                Id = model.ForPerson.Id,
                FirstName = model.ForPerson.FirstName,
                LastName = model.ForPerson.LastName
            } : null,
            Price = model.Price
        };
    }

    public static ChristmasItemModel AsModel(this ChristmasItemViewModel viewModel)
    {
        return new ChristmasItemModel
        {
            Id = viewModel.Id,
            Title = viewModel.Title,
            WebsiteUrl = viewModel.WebsiteUrl,
            PictureUrl = viewModel.PictureUrl,
            Description = viewModel.Description,
            Price = viewModel.Price,
            ForPerson = viewModel.ForPerson != null
                ? new PersonModel
                {
                    Id = viewModel.ForPerson.Id,
                    FirstName = viewModel.ForPerson?.FirstName!,
                    LastName = viewModel.ForPerson?.LastName
                }
                : null,
            ForPersonId = viewModel.ForPerson?.Id
        };
    }
}