namespace WishList.Maui.Models;

public record WishItem(
    string PictureUrl,
    string Title,
    string WebsiteUrl,
    string Description,
    int? Id = null
);

