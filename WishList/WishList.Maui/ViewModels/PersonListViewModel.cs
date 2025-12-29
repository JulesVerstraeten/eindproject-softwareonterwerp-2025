using System.Collections.ObjectModel;
using System.Windows.Input;
using WishList.BL.Interfaces;
using WishList.Maui.Extensions;
using WishList.Maui.Interfaces;
using WishList.Maui.Models;
using WishList.Maui.ViewModels.Base;

namespace WishList.Maui.ViewModels;

public class PersonListViewModel : ViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IPersonService _personService;
    
    public PersonListViewModel(INavigationService navigationService,  IPersonService personService)
    {
        _navigationService = navigationService;
        _personService = personService;
        
        GoToPersonDetailPageCommand = new Command(_goToPersonDetailPage);

        People = [];
    }
    
    // INITIALIZE ASYNC

    public async Task InitializeAsync()
    {
        var peopleResult = await _personService.GetAllPersonsAsync();
        
        People.Clear();
        
        foreach (var person in peopleResult)
        {
            People.Add(person.AsViewModel());
        }
    }
    
    // PROPERTIES
    
    private ObservableCollection<PersonViewModel> _people;
    public ObservableCollection<PersonViewModel> People
    {
        get => _people;
        set => SetProperty(ref _people, value);
    }
    
    private PersonViewModel? _selectedPerson;
    public PersonViewModel? SelectedPerson
    {
        get => _selectedPerson;
        set
        {
            if (!SetProperty(ref _selectedPerson, value)) return;
            if (_selectedPerson == null) return;
            _navigationService.NavigateToPersonDetailPageAsync(value);
            _selectedPerson = null;
        }
    }
    
    // COMMANDS
    public ICommand GoToPersonDetailPageCommand { get; }

    private void _goToPersonDetailPage()
    {
        _navigationService.NavigateToPersonDetailPageAsync();
    }
}