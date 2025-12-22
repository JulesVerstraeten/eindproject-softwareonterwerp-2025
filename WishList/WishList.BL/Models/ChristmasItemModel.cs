namespace WishList.BL.Models;

public record ChristmasItemModel
{
    public int? Id { get; init; }
    public required string Title { get; init; }
    public required string WebsiteUrl { get; init; }
    public string? PictureUrl { get; init; } 
    public string? Description { get; init; }
    public double? Price { get; init; }
    public PersonModel? ForPerson { get; set; }
    public int? ForPersonId { get; init; }
};