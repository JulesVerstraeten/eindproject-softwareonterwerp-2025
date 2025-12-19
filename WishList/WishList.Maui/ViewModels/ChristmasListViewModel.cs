using System.Collections.ObjectModel;
using System.Windows.Input;
using WishList.Maui.Interfaces;
using WishList.Maui.Models;
using WishList.Maui.ViewModels.Base;

namespace WishList.Maui.ViewModels;

public class ChristmasListViewModel : ViewModel
{
    private readonly INavigationService _navigationService;
    
    // CONSTRUCTOR

    public ChristmasListViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        
        GoToChristmasDetailPageCommand = new Command(_goToChristmasDetailPage);
        GoToPeopleListPageCommand = new Command(_goToPeoplePage);

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

        ChristmasItems = new ObservableCollection<ChristmasItemUiModel>
        {
            new ChristmasItemUiModel
            {
                Id = 1,
                PictureUrl =
                    "https://i5.walmartimages.com/seo/Nerf-N-Series-Sprinter-Motorized-Blaster-16-Nerf-N1-Darts-Compatible-Only-with-Nerf-N-Series_5744fbc4-2103-4028-8292-7e020123101a.c1bd7364d9fe1cc91b23a48215b434c5.jpeg?odnHeight=573&odnWidth=573&odnBg=FFFFFF",
                Title = "Nerf",
                Description = "Coole gun",
                WebsiteUrl = "Site",
                Price = 14.56,
                ForPerson = People[0]
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
    
    private ChristmasItemUiModel? _selectedChristmasItem = null;
    public ChristmasItemUiModel? SelectedChristmasItem
    {
        get => _selectedChristmasItem;
        set
        {
            SetProperty(ref _selectedChristmasItem, value);
            _navigationService.NavigateToChristmasDetailPageAsync(_selectedChristmasItem);
        }
    }

    private ObservableCollection<ChristmasItemUiModel> _christmasItems = new ObservableCollection<ChristmasItemUiModel>();
    public ObservableCollection<ChristmasItemUiModel> ChristmasItems
    {
        get => _christmasItems;
        set => SetProperty(ref _christmasItems, value);
    }
    
    // COMMANDS
    
    public ICommand GoToChristmasDetailPageCommand { get; }
    public ICommand GoToPeopleListPageCommand { get; }

    private void _goToChristmasDetailPage()
    {
        _navigationService.NavigateToChristmasDetailPageAsync();
    }

    private void _goToPeoplePage()
    {
        _navigationService.NavigateToPeopleListPageAsync();
    }
}