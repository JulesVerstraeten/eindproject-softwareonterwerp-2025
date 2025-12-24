using WishList.BL.Models;
using WishList.Maui.Models;

namespace WishList.Maui.Extensions;

public static class PersonMapper
{
    public static PersonViewModel AsViewModel(this PersonModel model)
    {
        return new PersonViewModel
        {
            Id = model.Id ?? 0,
            FirstName = model.FirstName,
            LastName = model.LastName ?? string.Empty,
        };
    }

    public static PersonModel AsModel(this PersonViewModel viewModel)
    {
        return new PersonModel
        {
            Id = viewModel.Id,
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
        };
    }
}