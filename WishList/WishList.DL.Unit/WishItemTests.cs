using System.Threading.Tasks;
using WishList.DL.Entities;
using WishList.DL.Interfaces;
using WishList.DL.Repositories;
using Xunit;

namespace WishList.DL.Unit;

public class WishItemTests
{
    private readonly WishlistDbContext _dbContext;
    private readonly IWishItemRepository _wishItemRepository;

    public WishItemTests()
    {
        _dbContext = new WishlistDbContext(":memory:");
        _dbContext.Connection.CreateTableAsync<WishItemEntity>().Wait();

        _wishItemRepository = new WishItemRepository(_dbContext);
    }

    [Fact]
    public async Task SaveAndRetrieveWishItems()
    {
        var item1 = new WishItemEntity
        {
            Title = "Nerf Gun",
            WebsiteUrl = "www.shop.com",
            Description = "Cool toy",
            PictureUrl = "https://example.com/nerf.jpg"
        };

        var item2 = new WishItemEntity
        {
            Title = "Book",
            WebsiteUrl = "www.bookstore.com",
            Description = "Interesting read",
            PictureUrl = "https://example.com/book.jpg"
        };

        await _wishItemRepository.SaveWishItemAsync(item1);

        var items = await _wishItemRepository.GetAllWishItemAsync();
        Assert.Single(items);
        Assert.Equal("Nerf Gun", items[0].Title);

        await _wishItemRepository.SaveWishItemAsync(item2);

        items = await _wishItemRepository.GetAllWishItemAsync();
        Assert.Equal(2, items.Count);
        Assert.Equal("Nerf Gun", items[0].Title);
        Assert.Equal("Book", items[1].Title);

        item1.Title = "Super Nerf Gun";
        await _wishItemRepository.SaveWishItemAsync(item1);

        items = await _wishItemRepository.GetAllWishItemAsync();
        Assert.Equal("Super Nerf Gun", items[0].Title);

        var fetchedItem = await _wishItemRepository.GetWishItemByIdAsync(item1.Id);
        Assert.Equal("Super Nerf Gun", fetchedItem.Title);
    }
}
