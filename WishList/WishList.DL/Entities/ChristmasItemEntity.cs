using SQLite;

namespace WishList.DL.Entities;

public class ChristmasItemEntity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; init; }
    public string? PictureUrl { get; set; }
    public string Title { get; set; } = string.Empty;
    public string WebsiteUrl { get; set; } = string.Empty;
    public string? Description { get; set; }
    public double? Price { get; set; }
    public int? ForPersonId { get; set; }
    [Ignore]
    public PersonEntity? ForPerson { get; set; } = null;
}