using WishList.BL.Interfaces;
using WishList.BL.Models;
using WishList.BL.Services;
using WishList.DL.Interfaces;
using WishList.DL;
using WishList.DL.Entities;
using WishList.DL.Repositories;

namespace WishList.BL.Unit;

public class PersonServiceTests
{
    private readonly IPersonService _personService;

    public PersonServiceTests()
    {
        var dbContext = new WishlistDbContext(":memory:");
        dbContext.Connection.CreateTableAsync<PersonEntity>().Wait();
        IPersonRepository personRepository = new PersonRepository(dbContext);
        _personService = new PersonService(personRepository);
    }

    [Fact]
    public async Task AddPersonTest()
    {
        var modelToAdd = new PersonModel
        {
            Id = 0,
            FirstName = "John",
            LastName = "Doe"
        };
        var modelResult = await _personService.SavePersonAsync(modelToAdd);
        Assert.Equal(modelResult.Id, 1);
    }

    [Fact]
    public async Task UpdatePersonTest()
    {
        var modelToAdd = new PersonModel
        {
            Id = 0,
            FirstName = "John",
            LastName = "Doe"
        };
        var modelToUpdate = new PersonModel
        {
            Id = 0,
            FirstName = "Jane",
            LastName = "Doe"
        };
        var modelResult = await _personService.SavePersonAsync(modelToUpdate);
        Assert.Equal(modelResult.Id, 1);
        Assert.Equal("Jane", modelResult.FirstName);
    }

    [Fact]
    public async Task GetAllPersonTest()
    {
        var modelToAdd = new PersonModel
        {
            Id = 0,
            FirstName = "John",
            LastName = "Doe"
        };
        var modelResult = await _personService.SavePersonAsync(modelToAdd);
        var result = await _personService.GetAllPersonsAsync();
        Assert.Equal(result[0].Id, 1);
    }

    [Fact]
    public async Task GetPersonByIdTest()
    {
        var modelToAdd = new PersonModel
        {
            Id = 0,
            FirstName = "John",
            LastName = "Doe"
        };
        var modelResult = await _personService.SavePersonAsync(modelToAdd);
        var result = await _personService.GetPersonByIdAsync(1);
        Assert.Equal(result.Id, 1);
    }
}