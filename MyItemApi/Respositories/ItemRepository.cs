using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyItemApi.Data.Entities;
using MyItemApi.Model;
using MyNoteApi.Data;
using MyNoteApi.Data.Entities;

namespace MyItemApi.Respositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ItemContext _context;
        private readonly IMapper _mapper;

        public ItemRepository(ItemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<HierarchyView> AddHierarchy(HierarchyView hierarchyView)
        {
            throw new NotImplementedException();
        }

        public async Task<ItemAttributeView> AddItemAttributeView(ItemAttributeView itemAttributeView)
        {
            // check if the attributeNameIa already exist
            var allAttributeValueIdsForItem = await _context.ItemAttributes.Where(a => a.ItemId == itemAttributeView.ItemId).Select(b => b.AttributeValueId).ToListAsync();
            var allAttributeNameIdsForItem = await _context.AttributeValues.Where(a => allAttributeValueIdsForItem.Contains(a.AttributeValueId)).Select(b => b.AttributeNameId).ToListAsync();
            if (allAttributeNameIdsForItem.Contains(itemAttributeView.AttributeNameId))
            {
                throw new Exception("Cannot add itemAttribute with same AttributeNameId");
            }

            ItemAttribute newItemAttribute = _mapper.Map<ItemAttributeView, ItemAttribute>(itemAttributeView);

            var attributeValue = await _context.AttributeValues.Include(a=>a.AttributeName).FirstOrDefaultAsync(a => a.AttributeNameId == itemAttributeView.AttributeNameId && a.AttributeValueId == itemAttributeView.AttributeValueId);
            if(attributeValue == null)
            {
                throw new Exception("Invalid AttributeNameId or AttributeValueId");
            }

            Log log = new Log { CreatedById = 2, CreatedAt = DateTime.UtcNow, UpdatedById = 2, UpdatedAt = DateTime.UtcNow };
            newItemAttribute.Log = log;
            _context.Add(newItemAttribute);
            await _context.SaveChangesAsync();

            ItemAttributeView savedItemAttributeView = _mapper.Map<AttributeValue, ItemAttributeView>(attributeValue);
            savedItemAttributeView.ItemId = newItemAttribute.ItemId;
            savedItemAttributeView.LogId = newItemAttribute.LogId;
            savedItemAttributeView.ItemAttributeId = newItemAttribute.ItemAttributeId;

            return savedItemAttributeView;
        }

        public async Task<ItemDataView> AddItemDataView(ItemDataView itemDataView)
        {
            ItemData newItemData = _mapper.Map<ItemDataView, ItemData>(itemDataView);
            Log log = new Log { CreatedById = 2, CreatedAt = DateTime.UtcNow, UpdatedById = 2, UpdatedAt = DateTime.UtcNow };
            newItemData.Log = log;

            _context.Add(newItemData);

            await _context.SaveChangesAsync();

            return _mapper.Map<ItemData, ItemDataView>(newItemData);
        }

        public async Task<ItemTextView> AddItemTextView(ItemTextView itemTextView)
        {
            ItemText newItemText = _mapper.Map<ItemTextView, ItemText>(itemTextView);
            Log log = new Log { CreatedById = 2, CreatedAt = DateTime.UtcNow, UpdatedById = 2, UpdatedAt = DateTime.UtcNow };
            newItemText.Log = log;

            _context.Add(newItemText);

            await _context.SaveChangesAsync();

            return _mapper.Map<ItemText, ItemTextView>(newItemText);
        }

        public async Task<ItemView> AddItemView(ItemView itemView)
        {
            Item newItem = _mapper.Map<ItemView, Item>(itemView);
            Log log = new Log { CreatedById = 2, CreatedAt = DateTime.UtcNow, UpdatedById = 2, UpdatedAt = DateTime.UtcNow };
            newItem.Log = log;

            if(newItem.ItemTexts != null)
            {
                foreach (var itemText in newItem.ItemTexts)
                {
                    Log log1 = new Log { CreatedById = 2, CreatedAt = DateTime.UtcNow, UpdatedById = 2, UpdatedAt = DateTime.UtcNow };
                    itemText.Log = log1;
                }
            }

            if (newItem.ItemDatas != null)
            {
                foreach (var itemData in newItem.ItemDatas)
                {
                    Log log2 = new Log { CreatedById = 2, CreatedAt = DateTime.UtcNow, UpdatedById = 2, UpdatedAt = DateTime.UtcNow };
                    itemData.Log = log2;
                }
            }

            _context.Add(newItem);
            await _context.SaveChangesAsync();

            return _mapper.Map<Item, ItemView>(newItem);
        }

        public async Task DeleteItemAttributeViewById(int itemAttributeId)
        {
            var itemAttribute = await _context.ItemAttributes.FirstOrDefaultAsync(a => a.ItemAttributeId == itemAttributeId);
            _context.Remove(itemAttribute);
            await _context.SaveChangesAsync();
        }

        public Task<HierarchyView> GetHierarchyById(int hierarchyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<HierarchyView>> GetHierarchyViewsByParentHierarchyId(int parentHierarchyId)
        {
            throw new NotImplementedException();
        }

        public async Task<ItemAttributeView> GetItemAttributeViewByItemAttributeId(int itemAttributeId)
        {
            var itemAttribute = await _context.ItemAttributes.FirstOrDefaultAsync(a=>a.ItemAttributeId == itemAttributeId);

            var itemAttributeView = _mapper.Map<ItemAttribute, ItemAttributeView>(itemAttribute);

            var attributeValue = await _context.AttributeValues.Include(a => a.AttributeName).FirstOrDefaultAsync(aa=>aa.AttributeValueId == itemAttribute.AttributeValueId);

            itemAttributeView.AttributeNameId = attributeValue.AttributeNameId;
            itemAttributeView.AttributeName = attributeValue.AttributeName.Name;
            itemAttributeView.AttributeValue = attributeValue.Value;

            return itemAttributeView;
        }

        public async Task<IEnumerable<ItemAttributeView>> GetItemAttributeViewsByItemId(int itemId)
        {
            var itemAttributes = await _context.ItemAttributes.Where(i => i.ItemId == itemId).ToListAsync();

            var itemAttributeViews =_mapper.Map<IEnumerable<ItemAttribute>, IEnumerable<ItemAttributeView>>(itemAttributes);

            var attributevalueIdList = itemAttributeViews.Select(a => a.AttributeValueId).ToList();

            var attributeValues = await _context.AttributeValues.Include(a => a.AttributeName).Where(aa => attributevalueIdList.Contains(aa.AttributeValueId)).ToListAsync();

            var itemAttributeViews1 = _mapper.Map<IEnumerable<AttributeValue>, IEnumerable<ItemAttributeView>>(attributeValues);

            foreach (var itemAttributeView in itemAttributeViews)
            {
                var temp = itemAttributeViews1.FirstOrDefault(a => a.AttributeValueId == itemAttributeView.AttributeValueId);
                itemAttributeView.AttributeNameId = temp.AttributeNameId;
                itemAttributeView.AttributeName = temp.AttributeName;
                itemAttributeView.AttributeValue = temp.AttributeValue;
            }

            return itemAttributeViews;

        }

        public async Task<ItemDataView> GetItemDataViewById(int itemId, int itemDataId)
        {
            var itemData = await _context.ItemDatas.FirstOrDefaultAsync(i => i.ItemId == itemId && i.ItemDataId == itemDataId);

            return _mapper.Map<ItemData, ItemDataView>(itemData);
        }

        public async Task<IEnumerable<ItemDataView>> GetItemDataViewsByItemId(int itemId)
        {
            var itemDatas = await _context.ItemDatas.Where(i => i.ItemId == itemId).ToListAsync();

            return _mapper.Map<IEnumerable<ItemData>, IEnumerable<ItemDataView>>(itemDatas);
        }

        public async Task<ItemTextView> GetItemTextViewById(int itemId, int itemTextId)
        {
            var itemText = await _context.ItemTexts.FirstOrDefaultAsync(i => i.ItemId == itemId && i.ItemTextId == itemTextId);

            return _mapper.Map<ItemText, ItemTextView>(itemText);
        }

        public async Task<IEnumerable<ItemTextView>> GetItemTextViewsByItemId(int itemId)
        {
            var itemTexts = await _context.ItemTexts.Where(i => i.ItemId == itemId).ToListAsync();

            return _mapper.Map<IEnumerable<ItemText>, IEnumerable<ItemTextView>>(itemTexts);
        }

        public async Task<ItemView> GetItemViewById(int itemId)
        {
            var item = await _context.Items.Include(i => i.ItemTexts).Include(i=>i.ItemDatas).FirstOrDefaultAsync(i => i.ItemId == itemId);

            return _mapper.Map<Item, ItemView>(item);
        }

        public async Task<IEnumerable<ItemView>> GetItemViewsByOwnerId(int ownerId)
        {
            var items = await _context.Items.Where(n => n.OwnerId == ownerId).ToListAsync();

            return _mapper.Map<IEnumerable<Item>, IEnumerable<ItemView>>(items);

        }

        public async Task<IEnumerable<ItemView>> SearchItemViewsWithOwnerId(int ownerId, string searchName)
        {
            var items = await _context.Items.Where(n => (n.OwnerId == ownerId) && n.Name.Contains(searchName)).ToListAsync();

            return _mapper.Map<IEnumerable<Item>, IEnumerable<ItemView>>(items);
        }
    }
}
