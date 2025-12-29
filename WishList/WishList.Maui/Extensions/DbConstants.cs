namespace WishList.Maui.Extensions;

public abstract class DbConstants
{
    private const string DatabaseFilename = "WishList.db3";
    
    public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
}