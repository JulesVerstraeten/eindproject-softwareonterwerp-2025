using SQLite;

namespace WishList.DL.Entities;

public class PersonEntity
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; init; }
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
}