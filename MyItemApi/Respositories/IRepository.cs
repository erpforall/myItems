using MyItemApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Respositories
{
    public interface IRepository
    {
        Task<ItemView> AddItemView(ItemView itemView);
        Task<ItemView> GetItemViewById(int itemId);
        Task<IEnumerable<ItemView>> GetItemViewsByOwnerId(int ownerId);
        Task<HierarchyView> GetHierarchyById(int hierarchyId);
        Task<HierarchyView> AddHierarchy(HierarchyView hierarchyView);
        Task<IEnumerable<HierarchyView>> GetHierarchyViewsByParentHierarchyId(int parentHierarchyId);

    }
}
