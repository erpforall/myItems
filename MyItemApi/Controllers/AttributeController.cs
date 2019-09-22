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


        // GET: api/Item/5
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

        // POST: api/Item
        [HttpPost("name")]
        public async Task<ActionResult<AttributeNameView>> Post([FromBody] AttributeNameView attrNameView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdeattrNameView = await _attributeRepository.AddAttributeName(attrNameView.Name);

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


        // GET: api/Item/5
        [HttpDelete("name/{id}")]
        public async Task Delete(int id)
        {
            await _attributeRepository.DeleteAttributeNameById(id);
        }

        // GET: api/Item/5
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

        // POST: api/Item
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

        // GET: api/Item/5
        [HttpDelete("value/{id}")]
        public async Task DeleteValue(int id)
        {
            await _attributeRepository.DeleteAttributeValueById(id);
        }

    }
}