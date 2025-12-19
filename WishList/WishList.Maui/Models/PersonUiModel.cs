namespace WishList.Maui.Models;

public class PersonUiModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; }  = string.Empty;
    public string FullName => $"{FirstName} {(string.IsNullOrEmpty(LastName) ? string.Empty : LastName)}".Trim();

    public PersonUiModel()
    {
        
    }
    public PersonUiModel(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }
}