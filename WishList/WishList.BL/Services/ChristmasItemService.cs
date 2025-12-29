using System.Diagnostics;
using WishList.BL.Exceptions;
using WishList.BL.Extensions;
using WishList.BL.Interfaces;
using WishList.BL.Models;
using WishList.DL.Interfaces;

namespace WishList.BL.Services;

public class ChristmasItemService(IChristmasItemRepository christmasItemRepository) : IChristmasItemService
{
    public async Task<List<ChristmasItemModel>> GetAllChristmasItemsAsync()
    {
        try
        {
            var entities = await christmasItemRepository.GetAllChristmasItemsAsync();
            var models = entities.Select(ChristmasItemMapper.AsModel).ToList();
            return models;
        }
        catch (Exception ex)
        {
            throw new ServiceException("Error while fetching all ChristmasItems", ex);
        }
    }

    public async Task<ChristmasItemModel> GetChristmasItemByIdAsync(int id)
    {
        try
        {
            var entity = await christmasItemRepository.GetChristmasItemByIdAsync(id);
            var model = entity.AsModel();
            return model;
        }
        catch (Exception ex)
        {
            throw new ServiceException("Error while fetching ChristmasItem by ID", ex);
        }
    }

    public async Task<ChristmasItemModel> SaveChristmasItemAsync(ChristmasItemModel item)
    {        
        try
        {
            var entity = item.AsEntity();
            await christmasItemRepository.SaveChristmasItemAsync(entity);
            return entity.AsModel();
        }
        catch (Exception ex)
        {
            throw new ServiceException("Error while saving ChristmasItem", ex);
        }
    }
}