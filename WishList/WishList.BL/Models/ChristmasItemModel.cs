namespace WishList.BL.Models;

public record ChristmasItemModel
(
    string Title,
    string WebsiteUrl,
    int? Id = null,
    string? PictureUrl = null,
    string? Description = null,
    PersonModel? ForPerson = null,
    double? Price = null
);