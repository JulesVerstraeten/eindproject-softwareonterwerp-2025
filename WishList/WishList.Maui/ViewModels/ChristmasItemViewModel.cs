using System.ComponentModel;
using System.Globalization;

namespace WishList.Maui.Models;

public class ChristmasItemViewModel : WishItemViewModel, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public int? Id { get; set; }
    public string? PictureUrl { get; set; }
    public string Title { get; set; } = string.Empty;
    public string WebsiteUrl { get; set; } = string.Empty;
    public string? Description  { get; set; }
    private PersonViewModel? _forPerson;
    public PersonViewModel? ForPerson
    {
        get => _forPerson;
        set
        {
            if (_forPerson != value)
            {
                _forPerson = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ForPerson)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ForPersonName)));
            }
        }
    }
    public string? ForPersonName => ForPerson?.FullName;
    public double? Price { get; set; }
    public string? PriceString => Price?.ToString("C", CultureInfo.GetCultureInfo("nl-NL"));
    
    public ChristmasItemViewModel() : base() {}

    public ChristmasItemViewModel(int? id, string pictureUrl, string title, string websiteUrl, string description, double price, PersonViewModel? forPerson = null)
        : base(id, pictureUrl, title, websiteUrl, description)
    {
        ForPerson = forPerson;
        Price =  price;
    }

    public override string ToString()
    {
        return $"Id: {Id} \nPicture: {PictureUrl} \nTitle: {Title} \nPrice: {PriceString} \nWebsite: {WebsiteUrl} \nPerson: {ForPersonName} \nDescription: {Description}";
    }
}