using MyItemApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyItemApi.Respositories
{
    public interface IAttributeRepository
    {
        Task<AttributeNameView> AddAttributeName(string attrName);
        Task<AttributeNameView> GetAttributeNameById(int attrNameId);
        Task<AttributeNameView> UpdateAttributeName(int attrNameId, string attrName);
        Task DeleteAttributeNameById(int attributeNameId);

        Task<AttributeValueView> AddAttributeValue(int attrNameId, string attrValue);
        Task<AttributeValueView> GetAttributeValueById(int attrValueId);
        Task<AttributeValueView> UpdateAttributeValue(int attrNameId, int attrValueId, string attrValue);
        Task DeleteAttributeValueById(int attrValueId);

    }
}
