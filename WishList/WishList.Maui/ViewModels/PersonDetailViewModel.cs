using System.Diagnostics;
using System.Windows.Input;
using WishList.Maui.Interfaces;
using WishList.Maui.Models;
using WishList.Maui.Services;
using WishList.Maui.ViewModels.Base;

namespace WishList.Maui.ViewModels;

public class PersonDetailViewModel : ViewModel, IQueryAttributable
{
    private readonly INavigationService _navigationService;

    public PersonDetailViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        
        CancelCommand = new Command(Cancel);
        SavePersonCommand = new Command(SavePerson);

        PersonToSave = new Person();
    }
    
    // PROPERTIES

    private Person _personToSave;
    public Person PersonToSave
    {
        get => _personToSave;
        set => SetProperty(ref _personToSave, value);
    }
    
    private string _personToSaveError;
    public string PersonToSaveError
    {
        get => _personToSaveError;
        set => SetProperty(ref _personToSaveError, value);
    }
    
    // COMMANDS
    
    public ICommand CancelCommand { get; }
    public ICommand SavePersonCommand { get; }

    private void Cancel() => _navigationService.GoBackAsync();

    private void SavePerson()
    {
        bool isValid = true;

        if (string.IsNullOrWhiteSpace(PersonToSave.FirstName))
        {
            PersonToSaveError = "First name is required";
            isValid = false;
        }
        else
        {
            PersonToSaveError = string.Empty;
        }
        
        if (!isValid) return;
        
        Debugger.Log(1, "Person", PersonToSave.FullName);
    }
    
    // PARAMETER CHECKER


    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!query.TryGetValue(NavigationParameters.Person, out var personItem) ||
            personItem is not Person person) return;
        PersonToSave = person;
    }
}