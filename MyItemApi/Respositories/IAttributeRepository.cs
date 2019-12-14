using MyItemApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Respositories
{
    public interface IAttributeRepository
    {
        Task<AttributeCategoryView> AddAttributeCategory(string attrCategoryName);
        Task<AttributeCategoryView> GetAttributeCategoryById(int attrCategoryId);
        Task<AttributeCategoryView> UpdateAttributeCategory(int attrCategoryId, string attrCategoryName);
        Task DeleteAttributeCategoryById(int attributeCategoryId);

        Task<AttributeNameView> AddAttributeName(string attrName, int categoryId);
        Task<IEnumerable<AttributeNameView>> GetAttributeNamesByCategoryId(int attrCategoryId, bool includeValues);
        Task<AttributeNameView> GetAttributeNameById(int attrNameId);
        Task<AttributeNameView> UpdateAttributeName(int attrNameId, string attrName, int categoryId);
        Task DeleteAttributeNameById(int attributeNameId);

        Task<AttributeValueView> AddAttributeValue(int attrNameId, string attrValue);
        Task<IEnumerable<AttributeValueView>> GetAttributeValuesByNameId(int attrNameId);
        Task<AttributeValueView> GetAttributeValueById(int attrValueId);
        Task<AttributeValueView> UpdateAttributeValue(int attrNameId, int attrValueId, string attrValue);
        Task DeleteAttributeValueById(int attrValueId);

    }
}
