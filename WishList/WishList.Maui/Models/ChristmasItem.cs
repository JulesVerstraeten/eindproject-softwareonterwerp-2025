namespace WishList.Maui.Models;

public record ChristmasItem
(
    int Id,
    string PictureUrl,
    string Title,
    string WebsiteUrl,
    string Description,
    Person ForPerson
) : WishItem
(
    Id,
    PictureUrl,
    Title,
    WebsiteUrl,
    Description
);