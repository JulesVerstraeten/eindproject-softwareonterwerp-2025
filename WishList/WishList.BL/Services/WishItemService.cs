using WishList.BL.Exceptions;
using WishList.BL.Extensions;
using WishList.BL.Interfaces;
using WishList.BL.Models;
using WishList.DL.Interfaces;

namespace WishList.BL.Services;

public class WishItemService(IWishItemRepository wishItemRepository) : IWishItemService
{
    public async Task<List<WishItemModel>> GetAllWishItemsAsync()
    {
        try
        {
            var entities = await wishItemRepository.GetAllWishItemAsync();
            var models = entities.Select(WishItemMapper.ToModel).ToList();
            return models;
        }
        catch (Exception ex)
        {
            throw new ServiceException("Error while retrieving all WishItems", ex);
        }
    }

    public async Task<WishItemModel> GetWishItemByIdAsync(int id)
    {
        try
        {
            var entity = await wishItemRepository.GetWishItemByIdAsync(id);
            var model = entity.ToModel();
            return model;
        }
        catch (Exception ex)
        {
            throw new ServiceException("Error while retrieving WishItem by ID", ex);
        }
    }

    public async Task<WishItemModel> SaveWishItemAsync(WishItemModel wishItem)
    {
        try
        {
            var entity = wishItem.ToEntity();
            await wishItemRepository.SaveWishItemAsync(entity);
            return entity.ToModel();
        }
        catch (Exception ex)
        {
            throw new ServiceException("Error while saving WishItem", ex);
        }
    }
}