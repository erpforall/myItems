using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyItemApi.Data.Entities;
using MyItemApi.Model;
using MyNoteApi.Data;
using MyNoteApi.Data.Entities;

namespace MyItemApi.Respositories
{
    public class Repository : IRepository
    {
        private readonly ItemContext _context;
        private readonly IMapper _mapper;

        public Repository(ItemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<HierarchyView> AddHierarchy(HierarchyView hierarchyView)
        {
            throw new NotImplementedException();
        }

        public async Task<ItemView> AddItemView(ItemView itemView)
        {
            Item newItem = _mapper.Map<ItemView, Item>(itemView);
            Log log = new Log { CreatedById = 2, CreatedAt = DateTime.UtcNow, UpdatedById = 2, UpdatedAt = DateTime.UtcNow };
            newItem.Log = log;

            _context.Add(newItem);
            await _context.SaveChangesAsync();

            return _mapper.Map<Item, ItemView>(newItem);
        }


        public Task<HierarchyView> GetHierarchyById(int hierarchyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HierarchyView>> GetHierarchyViewsByParentHierarchyId(int parentHierarchyId)
        {
            throw new NotImplementedException();
        }

        public async Task<ItemView> GetItemViewById(int itemId)
        {
            var item = await _context.Items.FindAsync(itemId);

            return _mapper.Map<Item, ItemView>(item);
        }

        public async Task<IEnumerable<ItemView>> GetItemViewsByOwnerId(int ownerId)
        {
            var items = await _context.Items.Where(n => n.OwnerId == ownerId).ToListAsync();

            return _mapper.Map<IEnumerable<Item>, IEnumerable<ItemView>>(items);

        }

    }
}
