using SQLite;

namespace WishList.DL.Entities;

public class ChristmasItemEntity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? PictureUrl { get; set; }
    public string Title { get; set; } = string.Empty;
    public string WebsiteUrl { get; set; } = string.Empty;
    public string? Description { get; set; }
    public double? Price { get; set; }
    public int? PersonId { get; set; }
}