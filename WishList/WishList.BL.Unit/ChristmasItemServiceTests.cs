using WishList.BL.Interfaces;
using WishList.BL.Models;
using WishList.BL.Services;
using WishList.DL;
using WishList.DL.Entities;
using WishList.DL.Interfaces;
using WishList.DL.Repositories;

namespace WishList.BL.Unit;

public class ChristmasItemServiceTests
{
    private readonly IChristmasItemService _christmasItemService;
    private readonly IPersonService _personService;

    private PersonModel _person1;
    private PersonModel _person2;
    
    private ChristmasItemModel _christmasItem1;
    private ChristmasItemModel _christmasItem2;
    private ChristmasItemModel _christmasItem3;

    public ChristmasItemServiceTests()
    {
        WishlistDbContext dbContext = new WishlistDbContext(":memory:");
        dbContext.Connection.CreateTablesAsync<ChristmasItemEntity, PersonEntity>();
        IPersonRepository personRepository = new PersonRepository(dbContext);
        _personService = new PersonService(personRepository);
        IChristmasItemRepository christmasItemRepository = new ChristmasItemRepository(dbContext);
        _christmasItemService = new ChristmasItemService(christmasItemRepository);

        _person1 = new PersonModel
        {
            FirstName = "John",
        };
        _person2 = new PersonModel
        {
            FirstName = "Jane",
            LastName = "Doe",
        };

        _christmasItem1 = new ChristmasItemModel
        {
            Title = "Boeken",
            WebsiteUrl = "www.gek.nl",
            ForPerson = _person1,
            ForPersonId = 1
        };

        _christmasItem2 = new ChristmasItemModel
        {
            Title = "Schoenen",
            WebsiteUrl = "ww.dwdw.wd",
            Price = 65.77,
            ForPerson = _person2,
            ForPersonId = 2
        };
        
        _christmasItem3 = new ChristmasItemModel
        {
            Title = "Pizza",
            WebsiteUrl = "ww.dwdw.wd"
        };
    }

    public async Task Initialize()
    {
        _person1 = await _personService.SavePersonAsync(_person1);
        _person2 = await _personService.SavePersonAsync(_person2);
        
        _christmasItem1 = await _christmasItemService.SaveChristmasItemAsync(_christmasItem1);
        _christmasItem2 = await _christmasItemService.SaveChristmasItemAsync(_christmasItem2);
        _christmasItem3 = await _christmasItemService.SaveChristmasItemAsync(_christmasItem3);
    }

    [Fact]
    public async Task SaveChristmasItemTest()
    {
        await Initialize();
        Assert.Equal(1, _christmasItem1.Id);
    }

    [Fact]
    public async Task GetAllChristmasItemTest()
    {
        await Initialize();
        var results = await _christmasItemService.GetAllChristmasItemsAsync();
        Assert.Equal("John", results[0].ForPerson?.FirstName);
        Assert.Equal(1, results[0].Id);
        Assert.Equal("Jane", results[1].ForPerson?.FirstName);
    }

    [Fact]
    public async Task GetChristmasItemTest()
    {
        await Initialize();
        var result = await _christmasItemService.GetChristmasItemByIdAsync(1);
        Assert.Equal("Boeken", result.Title);
        Assert.Equal("John", result.ForPerson?.FirstName);
    }

    [Fact]
    public async Task UpdateChristmasItemTest()
    {
        await Initialize();
        _christmasItem1 = new ChristmasItemModel
        {
            Id = _christmasItem1.Id,
            Title = _christmasItem1.Title,
            WebsiteUrl = _christmasItem1.WebsiteUrl,
            ForPerson = _person2,
            ForPersonId = _person2.Id
        };
        await _christmasItemService.SaveChristmasItemAsync(_christmasItem1);
        var result = await _christmasItemService.GetChristmasItemByIdAsync(1);
        Assert.Equal("Jane", result.ForPerson?.FirstName);
    }
}