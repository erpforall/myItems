using MyItemApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Respositories
{
    public interface IItemRepository
    {
        Task<ItemView> AddItemView(ItemView itemView);
        Task<ItemView> GetItemViewById(int itemId);
        Task<IEnumerable<ItemView>> GetItemViewsByOwnerId(int ownerId);
        Task<HierarchyView> GetHierarchyById(int hierarchyId);
        Task<HierarchyView> AddHierarchy(HierarchyView hierarchyView);
        Task<IEnumerable<HierarchyView>> GetHierarchyViewsByParentHierarchyId(int parentHierarchyId);

        Task<ItemTextView> AddItemTextView(ItemTextView itemTextView);
        Task<ItemTextView> GetItemTextViewById(int itemId, int itemTextId);
        Task<IEnumerable<ItemTextView>> GetItemTextViewsByItemId(int itemId);

        Task<ItemDataView> AddItemDataView(ItemDataView itemDataView);
        Task<ItemDataView> GetItemDataViewById(int itemId, int itemDataId);
        Task<IEnumerable<ItemDataView>> GetItemDataViewsByItemId(int itemId);
        Task<IEnumerable<ItemAttributeView>> GetItemAttributeViewsByItemId(int itemId);
        Task<ItemAttributeView> GetItemAttributeViewByItemAttributeId(int itemAttributeId);
        Task<ItemAttributeView> AddItemAttributeView(ItemAttributeView itemAttributeView);
        Task DeleteItemAttributeViewById(int itemAttributeId);
    }
}
