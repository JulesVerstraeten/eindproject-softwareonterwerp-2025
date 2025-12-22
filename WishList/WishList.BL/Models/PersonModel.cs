namespace WishList.BL.Models;

public record PersonModel
{
    public int? Id { get; init; }
    public required string FirstName { get; init; }
    public string? LastName { get; init; }
};