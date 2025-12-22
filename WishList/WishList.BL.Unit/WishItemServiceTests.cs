using WishList.BL.Interfaces;
using WishList.BL.Models;
using WishList.BL.Services;
using WishList.DL;
using WishList.DL.Entities;
using WishList.DL.Interfaces;
using WishList.DL.Repositories;

namespace WishList.BL.Unit;

public class WishItemServiceTests
{
    private readonly IWishItemService _wishItemService;
    
    private readonly WishItemModel _wishItem1;
    private readonly WishItemModel _wishItem2;
    private readonly WishItemModel _wishItem3;

    public WishItemServiceTests()
    {
        var context = new WishlistDbContext(":memory:");
        context.Connection.CreateTableAsync<WishItemEntity>();
        IWishItemRepository wishItemRepository = new WishItemRepository(context);
        _wishItemService = new WishItemService(wishItemRepository);

        _wishItem1 = new WishItemModel
        {
            Id = 0,
            Title = "Pizza",
            WebsiteUrl = "www.hh.nl",
            PictureUrl = null,
            Description = null
        };

        _wishItem2 = new WishItemModel
        {
            Id = 0,
            Title = "Boek",
            WebsiteUrl = "www.dwddw.nl",
            PictureUrl = "www.wdwd.com",
            Description = "Leuke boek"
        };

        _wishItem3 = new WishItemModel
        {
            Id = 0,
            Title = "Schoenen",
            WebsiteUrl = "www.dw.nl",
            PictureUrl = null,
            Description = null
        };
    }

    [Fact]
    public async Task CreateWishItemTest()
    {
        var result = await _wishItemService.SaveWishItemAsync(_wishItem1);
        Assert.Equal(result.Id, 1);
        Assert.Equal("Pizza", result.Title);
    }

    [Fact]
    public async Task UpdateWishItemTest()
    {
        var result = await _wishItemService.SaveWishItemAsync(_wishItem1);
        var updatedItem = new WishItemModel
        {
            Id = result.Id,
            Title = "Spaghetti",
            WebsiteUrl = "www.spaghetti.com",
        };
        updatedItem = await _wishItemService.SaveWishItemAsync(updatedItem);
        Assert.Equal(updatedItem.Id, result.Id);
        Assert.Equal("Pizza", result.Title);
        Assert.Equal("Spaghetti", updatedItem.Title);
    }

    [Fact]
    public async Task GetAllWishItemsTest()
    {
        await _wishItemService.SaveWishItemAsync(_wishItem1);
        await _wishItemService.SaveWishItemAsync(_wishItem2);
        await _wishItemService.SaveWishItemAsync(_wishItem3);
        
        var results = await _wishItemService.GetAllWishItemsAsync();
        
        Assert.NotEmpty(results);
        Assert.Equal(3, results.Count);
        Assert.Equal("Pizza", results[0].Title);
        Assert.Equal("Boek", results[1].Title);
        Assert.Equal("Schoenen", results[2].Title);
    }
    
    [Fact]
    public async Task GetWishItemByIdTest()
    {
        await _wishItemService.SaveWishItemAsync(_wishItem1);
        await _wishItemService.SaveWishItemAsync(_wishItem2);
        await _wishItemService.SaveWishItemAsync(_wishItem3);
        
        var result = await _wishItemService.GetWishItemByIdAsync(2);
        
        Assert.Equal("Boek", result.Title);
    }
}