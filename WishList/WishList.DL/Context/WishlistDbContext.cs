using SQLite;
using WishList.DL.Entities;

namespace WishList.DL.Context;

public sealed class WishlistDbContext
{
    public SQLiteAsyncConnection Connection { get; }

    public WishlistDbContext(string dbPath)
    {
        Connection = new SQLiteAsyncConnection(dbPath);
        Connection.CreateTablesAsync<PersonEntity, WishItemEntity, ChristmasItemEntity>().Wait();
    }
}