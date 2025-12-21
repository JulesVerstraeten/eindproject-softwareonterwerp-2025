namespace WishList.BL.Models;

public record WishItemModel
(
    string Title,
    string WebsiteUrl,
    int? Id = null,
    string? PictureUrl = null,
    string? Description = null
);