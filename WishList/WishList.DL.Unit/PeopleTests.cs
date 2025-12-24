using WishList.DL.Context;
using WishList.DL.Entities;
using WishList.DL.Interfaces;
using WishList.DL.Repositories;

namespace WishList.DL.Unit;

public class PeopleTests
{
    private readonly WishlistDbContext _dbContext;
    private readonly IPersonRepository _personRepository;

    public PeopleTests()
    {
        _dbContext = new WishlistDbContext(":memory:");
        _dbContext.Connection.CreateTableAsync<PersonEntity>().Wait();
        _personRepository = new PersonRepository(_dbContext);
    }
    
    [Fact]
    public async Task Test1()
    {
        var person1 = new PersonEntity
        {
            FirstName = "John",
            LastName = "Doe",
        };
        var person2 = new PersonEntity
        {
            FirstName = "Jane",
            LastName = "Doe",
        };
        
        await _personRepository.SavePersonAsync(person1);

        var people = await _personRepository.GetAllPeopleAsync();
        
        Assert.Single(people);
        
        await _personRepository.SavePersonAsync(person2);
        
        people = await _personRepository.GetAllPeopleAsync();
        
        Assert.Equal(2, people.Count);
        Assert.Equal("John", people[0].FirstName);
        Assert.Equal("Jane", people[1].FirstName);
        
        person1.FirstName = "Jean";
        
        await _personRepository.SavePersonAsync(person1);
        
        people = await _personRepository.GetAllPeopleAsync();
        
        Assert.Equal("Jean", people[0].FirstName); 
        
        person1 = await _personRepository.GetPersonByIdAsync(1);
        
        Assert.Equal("Jean", person1.FirstName);
    }
}