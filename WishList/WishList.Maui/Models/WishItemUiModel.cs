namespace WishList.Maui.Models;

public class WishItemUiModel
{
    public int? Id { get; set; }
    public string? PictureUrl { get; set; }
    public string Title { get; set; } = string.Empty;
    public string WebsiteUrl { get; set; } = string.Empty;
    public string? Description  { get; set; }

    public WishItemUiModel()
    {
    }
    
    public WishItemUiModel(int? id, string pictureUrl, string title, string websiteUrl, string description)
    {
        Id = id;
        PictureUrl = pictureUrl;
        Title = title;
        WebsiteUrl = websiteUrl;
        Description = description;
    }

    override public string ToString()
    {
        return $"{Id} \n {PictureUrl} \n {Title} \n {WebsiteUrl} \n {Description}";
    }
}
