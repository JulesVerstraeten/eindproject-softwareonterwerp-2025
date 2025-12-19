using System.Threading.Tasks;
using WishList.DL.Entities;
using WishList.DL.Interfaces;
using WishList.DL.Repositories;
using Xunit;

namespace WishList.DL.Unit;

public class ChristmasItemTests
{
    private readonly WishlistDbContext _dbContext;
    private readonly IChristmasItemRepository _christmasItemRepository;

    public ChristmasItemTests()
    {
        _dbContext = new WishlistDbContext(":memory:");
        _dbContext.Connection.CreateTableAsync<ChristmasItemEntity>().Wait();

        _christmasItemRepository = new ChristmasItemRepository(_dbContext);
    }

    [Fact]
    public async Task SaveAndRetrieveChristmasItems()
    {
        var item1 = new ChristmasItemEntity
        {
            Title = "Nerf Gun",
            WebsiteUrl = "www.shop.com",
            Description = "Cool toy",
            PictureUrl = "https://example.com/nerf.jpg",
            Price = 19.99,
            PersonId = 1
        };

        var item2 = new ChristmasItemEntity
        {
            Title = "Book",
            WebsiteUrl = "www.bookstore.com",
            Description = "Interesting read",
            PictureUrl = "https://example.com/book.jpg",
            Price = 12.50,
            PersonId = 2
        };

        await _christmasItemRepository.SaveChristmasItemAsync(item1);

        var items = await _christmasItemRepository.GetAllChristmasItemsAsync();
        Assert.Single(items);
        Assert.Equal("Nerf Gun", items[0].Title);
        Assert.Equal(19.99, items[0].Price);

        await _christmasItemRepository.SaveChristmasItemAsync(item2);

        items = await _christmasItemRepository.GetAllChristmasItemsAsync();
        Assert.Equal(2, items.Count);
        Assert.Equal("Nerf Gun", items[0].Title);
        Assert.Equal("Book", items[1].Title);

        item1.Title = "Super Nerf Gun";
        item1.Price = 24.99;
        await _christmasItemRepository.SaveChristmasItemAsync(item1);

        items = await _christmasItemRepository.GetAllChristmasItemsAsync();
        Assert.Equal("Super Nerf Gun", items[0].Title);
        Assert.Equal(24.99, items[0].Price);

        var fetchedItem = await _christmasItemRepository.GetChristmasItemByIdAsync(item1.Id);
        Assert.Equal("Super Nerf Gun", fetchedItem.Title);
        Assert.Equal(24.99, fetchedItem.Price);
    }
}
