namespace WishList.BL.Models;

public record WishItemModel
{
    public int? Id { get; init; }
    public required string Title { get; init; }
    public required string WebsiteUrl { get; init; }
    public string? PictureUrl { get; init; }
    public string? Description { get; init; }
};