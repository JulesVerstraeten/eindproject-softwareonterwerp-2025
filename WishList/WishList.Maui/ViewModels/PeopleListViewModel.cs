using System.Windows.Input;
using WishList.Maui.Interfaces;
using WishList.Maui.Models;
using WishList.Maui.ViewModels.Base;

namespace WishList.Maui.ViewModels;

public class PeopleListViewModel : ViewModel
{
    private readonly INavigationService _navigationService;
    
    public PeopleListViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        
        GoToPersonDetailPageCommand = new Command(_goToPersonDetailPage);

        People = new List<PersonUiModel>
        {
            new PersonUiModel
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
            },
            new PersonUiModel
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
            }
        };
    }
    
    // PROPERTIES
    
    private List<PersonUiModel> _people;
    public List<PersonUiModel> People
    {
        get => _people;
        set => SetProperty(ref _people, value);
    }
    
    private PersonUiModel _selectedPerson;
    public PersonUiModel SelectedPerson
    {
        get => _selectedPerson;
        set
        {
            SetProperty(ref _selectedPerson, value);
            _navigationService.NavigateToPersonDetailPageAsync(value);
        }
    }
    
    // COMMANDS
    public ICommand GoToPersonDetailPageCommand { get; }

    private void _goToPersonDetailPage()
    {
        _navigationService.NavigateToPersonDetailPageAsync();
    }
}