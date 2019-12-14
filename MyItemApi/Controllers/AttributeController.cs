using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyItemApi.Model;
using MyItemApi.Respositories;

namespace MyItemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttributeController : ControllerBase
    {

        private readonly IAttributeRepository _attributeRepository;

        public AttributeController(IAttributeRepository attributeRepository)
        {
            _attributeRepository = attributeRepository;
        }


        // GET: api/category/5
        [HttpGet("category/{id}")]
        public async Task<ActionResult<AttributeCategoryView>> GetCategory(int id)
        {
            var attributeCategoryView = await _attributeRepository.GetAttributeCategoryById(id);

            if (attributeCategoryView == null)
            {
                return NotFound();
            }

            return attributeCategoryView;
        }

        // POST: api/Category
        [HttpPost("Category")]
        public async Task<ActionResult<AttributeCategoryView>> PostCategory([FromBody] AttributeCategoryView attrCategoryView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdeattrCategoryView = await _attributeRepository.AddAttributeCategory(attrCategoryView.Name);

                    return CreatedAtAction("Get", new { id = createdeattrCategoryView.AttributeCategoryId }, createdeattrCategoryView);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

            }
            return BadRequest("Failed to save the AttributeCategory");
        }


        // DELETE: api/category/5
        [HttpDelete("category/{id}")]
        public async Task DeleteCategory(int id)
        {
            await _attributeRepository.DeleteAttributeCategoryById(id);
        }


        // GET: api/name?categoryId=1
        [HttpGet("name")]
        public async Task<IEnumerable<AttributeNameView>> GetAttributeNames(int categoryId, bool includeValues = false)
        {
            return await _attributeRepository.GetAttributeNamesByCategoryId(categoryId, includeValues);
        }

        // GET: api/name/5
        [HttpGet("name/{id}")]
        public async Task<ActionResult<AttributeNameView>> Get(int id)
        {
            var attributeNameView = await _attributeRepository.GetAttributeNameById(id);

            if(attributeNameView == null)
            {
                return NotFound();
            }

            return attributeNameView;
        }

        // POST: api/name
        [HttpPost("name")]
        public async Task<ActionResult<AttributeNameView>> Post([FromBody] AttributeNameView attrNameView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdeattrNameView = await _attributeRepository.AddAttributeName(attrNameView.Name, attrNameView.AttributeCategoryId);

                    return CreatedAtAction("Get", new { id = createdeattrNameView.AttributeNameId }, createdeattrNameView);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

            }
            return BadRequest("Failed to save the AttributeName");
        }


        // DELETE: api/name/5
        [HttpDelete("name/{id}")]
        public async Task Delete(int id)
        {
            await _attributeRepository.DeleteAttributeNameById(id);
        }


        // GET: api/value?nameId=1
        [HttpGet("value")]
        public async Task<IEnumerable<AttributeValueView>> GetAttributeValues(int nameId)
        {
            return await _attributeRepository.GetAttributeValuesByNameId(nameId);
        }

        // GET: api/value/5
        [HttpGet("value/{id}")]
        public async Task<ActionResult<AttributeValueView>> GetValue(int id)
        {
            var attributeValueView = await _attributeRepository.GetAttributeValueById(id);
            if(attributeValueView == null)
            {
                return NotFound();
            }
            return attributeValueView;
        }

        // POST: api/value
        [HttpPost("value")]
        public async Task<ActionResult<AttributeValueView>> PostValue([FromBody] AttributeValueView attrValueView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdeattrValueView = await _attributeRepository.AddAttributeValue(attrValueView.AttributeNameId, attrValueView.Value);

                    return CreatedAtAction("Get", new { id = createdeattrValueView.AttributeValueId }, createdeattrValueView);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

            }
            return BadRequest("Failed to save the AttributeValue");
        }

        // GET: api/value/5
        [HttpDelete("value/{id}")]
        public async Task DeleteValue(int id)
        {
            await _attributeRepository.DeleteAttributeValueById(id);
        }

    }
}