using System.Diagnostics;
using System.Windows.Input;
using WishList.Maui.Interfaces;
using WishList.Maui.Models;
using WishList.Maui.Services;
using WishList.Maui.ViewModels.Base;

namespace WishList.Maui.ViewModels;

public class ChristmasDetailViewModel : ViewModel, IQueryAttributable
{
    private INavigationService _navigationService;
    
    public ChristmasDetailViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        
        CancelCommand = new Command(Cancel);
        SaveChristmasItemCommand = new Command(SaveChristmasItem);

        ChristmasItem = new ChristmasItem();
        
        People = new List<Person>
        {
            new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
            },
            new Person
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
            }
        };
    }
    
    // PROPERTIES

    private List<Person> _people;
    public List<Person> People
    {
        get => _people;
        set => SetProperty(ref _people, value);
    }
    
    private ChristmasItem _christmasItem;
    public ChristmasItem ChristmasItem
    {
        get => _christmasItem;
        set => SetProperty(ref _christmasItem, value);
    }

    private string _priceInput;
    public string PriceInput
    {
        get => _priceInput;
        set => SetProperty(ref _priceInput, value);
    }

    private string _christmasItemError;
    public string ChristmasItemError
    {
        get => _christmasItemError;
        set => SetProperty(ref _christmasItemError, value);
    }
    
    // COMMANDS
    
    public ICommand CancelCommand { get; }
    public ICommand SaveChristmasItemCommand { get; }

    private void Cancel()
    {
        _navigationService.GoBackAsync();
    } 

    private void SaveChristmasItem()
    {
        bool isValid = true;

        if (string.IsNullOrEmpty(ChristmasItem.Title))
        {
            ChristmasItemError = "Title is required";
            isValid = false;
        } else if (!double.TryParse(PriceInput, out var price) && !string.IsNullOrWhiteSpace(PriceInput))
        {
            ChristmasItemError = "Price must be a floating-point number";
            isValid = false;
        }
        else
        {
            ChristmasItemError = string.Empty;
        }
        
        if (!isValid) return;
        
        ChristmasItem.Price = string.IsNullOrWhiteSpace(PriceInput) ? null : double.Parse(PriceInput) ;
        
        Debugger.Log(0, "Christmas item", ChristmasItem.ToString());
    }
    
    // PARAMETERS CHECKER
    
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!query.TryGetValue(NavigationParameters.ChristmasItem, out var christmasItem) ||
            christmasItem is not ChristmasItem item) return;
        
        ChristmasItem = item;

        if (item.ForPerson == null) return;
        var matchedPerson = People.FirstOrDefault(p => p.Id == item.ForPerson.Id);
        if (matchedPerson != null)
            ChristmasItem.ForPerson = matchedPerson;
    }
}