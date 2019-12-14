using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyItemApi.Data.Entities;
using MyItemApi.Model;
using MyNoteApi.Data;

namespace MyItemApi.Respositories
{
    public class AttributeRepository : IAttributeRepository
    {
        private readonly ItemContext _context;
        private readonly IMapper _mapper;

        public AttributeRepository(ItemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AttributeCategoryView> AddAttributeCategory(string attrCategoryName)
        {
            AttributeCategory attributeCategory = new AttributeCategory { Name = attrCategoryName };

            _context.AttributeCategories.Add(attributeCategory);
            await _context.SaveChangesAsync();

            return _mapper.Map<AttributeCategory, AttributeCategoryView>(attributeCategory);
        }

        public async Task<AttributeNameView> AddAttributeName(string attrName, int categoryId)
        {
            AttributeName attributeName = new AttributeName { Name = attrName, AttributeCategoryId = categoryId };

            _context.AttributeNames.Add(attributeName);
            await _context.SaveChangesAsync();

            return _mapper.Map<AttributeName, AttributeNameView>(attributeName);
        }

        public async Task<AttributeValueView> AddAttributeValue(int attrNameId, string attrValue)
        {
            AttributeValue attributeValue = new AttributeValue { AttributeNameId = attrNameId, Value = attrValue };

            _context.AttributeValues.Add(attributeValue);
            await _context.SaveChangesAsync();

            return _mapper.Map<AttributeValue, AttributeValueView>(attributeValue);
        }

        public async Task DeleteAttributeCategoryById(int attributeCategoryId)
        {
            AttributeCategory attributeCategory = await _context.AttributeCategories.Include(a => a.AttributeNames).FirstAsync(a => a.AttributeCategoryId == attributeCategoryId);

            _context.Remove(attributeCategory);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAttributeNameById(int attrNameId)
        {
            AttributeName attributeName = await _context.AttributeNames.Include(a => a.AttributeValues).FirstAsync(a => a.AttributeNameId == attrNameId);

            _context.Remove(attributeName);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAttributeValueById(int attrValueId)
        {
            AttributeValue attributeValue = await _context.AttributeValues.FirstAsync(a => a.AttributeValueId == attrValueId);

            _context.Remove(attributeValue);

            await _context.SaveChangesAsync();
        }

        public async Task<AttributeCategoryView> GetAttributeCategoryById(int attrCategoryId)
        {
            AttributeCategory attributeCategory = await _context.AttributeCategories.Include(a => a.AttributeNames).FirstOrDefaultAsync(a => a.AttributeCategoryId == attrCategoryId);

            return _mapper.Map<AttributeCategory, AttributeCategoryView>(attributeCategory);
        }

        public async Task<AttributeNameView> GetAttributeNameById(int attriNameId)
        {
            AttributeName attributeName =  await _context.AttributeNames.Include(a => a.AttributeValues).FirstOrDefaultAsync(a => a.AttributeNameId == attriNameId);

            return _mapper.Map<AttributeName, AttributeNameView>(attributeName);
        }

        public async Task<IEnumerable<AttributeNameView>> GetAttributeNamesByCategoryId(int attrCategoryId, bool includeValues)
        {
            IEnumerable<AttributeName> attributeNames;

            if(includeValues)
            {
                attributeNames = await _context.AttributeNames.Include(b => b.AttributeValues).Where(a => a.AttributeCategoryId == attrCategoryId).ToListAsync();
            } else
            {
                attributeNames = await _context.AttributeNames.Where(a => a.AttributeCategoryId == attrCategoryId).ToListAsync();
            }

            return _mapper.Map<IEnumerable<AttributeName>, IEnumerable<AttributeNameView>>(attributeNames);
        }

        public async Task<AttributeValueView> GetAttributeValueById(int attrValueId)
        {
            AttributeValue attributeValue = await _context.AttributeValues.FirstOrDefaultAsync(a => a.AttributeValueId == attrValueId);

            return _mapper.Map<AttributeValue, AttributeValueView>(attributeValue);
        }

        public async Task<IEnumerable<AttributeValueView>> GetAttributeValuesByNameId(int attrNameId)
        {
            var attributeValues = await _context.AttributeValues.Where(a => a.AttributeNameId == attrNameId).ToListAsync();

            return _mapper.Map<IEnumerable<AttributeValue>, IEnumerable<AttributeValueView>>(attributeValues);
        }

        public async Task<AttributeCategoryView> UpdateAttributeCategory(int attrCategoryId, string attrCategoryName)
        {
            AttributeCategory attributeCategory = new AttributeCategory { AttributeCategoryId = attrCategoryId, Name = attrCategoryName };

            _context.Attach(attributeCategory);

            await _context.SaveChangesAsync();

            return _mapper.Map<AttributeCategory, AttributeCategoryView>(attributeCategory);
        }

        public async Task<AttributeNameView> UpdateAttributeName(int attrNameId, string attrName, int categoryId)
        {
            AttributeName attributeName = new AttributeName { AttributeNameId = attrNameId, Name = attrName, AttributeCategoryId = categoryId };

            _context.Attach(attributeName);

            await _context.SaveChangesAsync();

            return _mapper.Map<AttributeName, AttributeNameView>(attributeName);

        }

        public async Task<AttributeValueView> UpdateAttributeValue(int attrNameId, int attrValueId, string attrValue)
        {
            AttributeValue attributeValue = new AttributeValue { AttributeNameId = attrNameId, AttributeValueId = attrValueId, Value = attrValue};

            _context.Attach(attributeValue);

            await _context.SaveChangesAsync();

            return _mapper.Map<AttributeValue, AttributeValueView>(attributeValue);
        }
    }
}
