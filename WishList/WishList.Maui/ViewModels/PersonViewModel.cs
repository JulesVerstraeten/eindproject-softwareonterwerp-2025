namespace WishList.Maui.Models;

public class PersonViewModel
{
    public int? Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public string FullName => $"{FirstName} {(string.IsNullOrEmpty(LastName) ? string.Empty : LastName)}".Trim();

    public PersonViewModel()
    {
        
    }
    public PersonViewModel(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
}