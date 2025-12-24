using System.Diagnostics;
using System.Windows.Input;
using WishList.BL.Interfaces;
using WishList.Maui.Extensions;
using WishList.Maui.Interfaces;
using WishList.Maui.Models;
using WishList.Maui.Services;
using WishList.Maui.ViewModels.Base;

namespace WishList.Maui.ViewModels;

public class PersonDetailViewModel : ViewModel, IQueryAttributable
{
    private readonly INavigationService _navigationService;
    private readonly IPersonService _personService;

    public PersonDetailViewModel(INavigationService navigationService, IPersonService personService)
    {
        _navigationService = navigationService;
        _personService = personService;
        
        CancelCommand = new Command(Cancel);
        SavePersonCommand = new Command(async void () => await SavePerson());

        PersonToSave = new PersonViewModel();
    }
    
    // PROPERTIES

    private PersonViewModel _personToSave;
    public PersonViewModel PersonToSave
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

    private async Task SavePerson()
    {
        var isValid = true;

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
        
        await _personService.SavePersonAsync(PersonToSave.AsModel());
        await _navigationService.GoBackAsync();
    }
    
    // PARAMETER CHECKER


    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!query.TryGetValue(NavigationParameters.Person, out var personItem) ||
            personItem is not PersonViewModel person) return;
        PersonToSave = person;
    }
}