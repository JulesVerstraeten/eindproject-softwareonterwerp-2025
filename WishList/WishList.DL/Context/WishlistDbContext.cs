using SQLite;
using WishList.DL.Entities;
using WishList.DL.Exceptions;

namespace WishList.DL.Context;

public sealed class WishlistDbContext
{
    public SQLiteAsyncConnection Connection { get; }

    public WishlistDbContext(string dbPath)
    {
        try
        {
            Connection = new SQLiteAsyncConnection(dbPath);
            Connection.CreateTablesAsync<PersonEntity, WishItemEntity, ChristmasItemEntity>().Wait();
        }
        catch (Exception e)
        {
            throw new RepositoryException("Error creating/initializing Wishlist", e);
        }
    }
}