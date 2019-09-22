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
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository repository)
        {
            _itemRepository = repository;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<IEnumerable<ItemView>> GetItems(int ownerId)
        {
            return await _itemRepository.GetItemViewsByOwnerId(ownerId);
        }

        // GET: api/Item/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ItemView> Get(int id)
        {
            return await _itemRepository.GetItemViewById(id);
        }

        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<ItemView>> Post([FromBody] ItemView itemView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdeItemView = await _itemRepository.AddItemView(itemView);

                    return CreatedAtAction("Get", new { id = createdeItemView.ItemId }, createdeItemView);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch ( Exception ex)
            {
                return BadRequest("Failed to save the Item: " + ex.Message);
            }
        }

        // PUT: api/Item/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // POST: api/Item/5/ItemText
        [HttpPost("{itemId}/ItemText")]
        public async Task<ActionResult<ItemTextView>> PostItemText(int itemId, [FromBody] ItemTextView itemTextView)
        {
            try
            {
                itemTextView.ItemId = itemId;

                if (ModelState.IsValid)
                {
                    var createdeItemTextView = await _itemRepository.AddItemTextView(itemTextView);

                    return CreatedAtAction("Get", new { id = createdeItemTextView.ItemId }, createdeItemTextView);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to save the ItemText: " + ex.Message);
            }
        }

        // POST: api/Item/5/ItemData
        [HttpPost("{itemId}/ItemData")]
        public async Task<ActionResult<ItemDataView>> PostItemData(int itemId, [FromBody] ItemDataView itemDataView)
        {
            try
            {
                itemDataView.ItemId = itemId;

                if (ModelState.IsValid)
                {
                    var createdeItemDataView = await _itemRepository.AddItemDataView(itemDataView);

                    return CreatedAtAction("Get", new { id = createdeItemDataView.ItemId }, createdeItemDataView);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to save the ItemData: " + ex.Message);
            }
        }


        // GET: api/Item/5/ItemText/1
        [HttpGet("{itemId}/ItemText/{itemTextId}", Name = "GetItemText")]
        public async Task<ActionResult<ItemTextView>> GetItemText(int itemId, int itemTextId)
        {
            var itemTextView = await _itemRepository.GetItemTextViewById(itemId, itemTextId);

            if(itemTextView == null)
            {
                return NotFound();
            }

            return itemTextView;
        }

        // GET: api/Item/5/ItemData/1
        [HttpGet("{itemId}/ItemData/{itemDataId}", Name = "GetItemData")]
        public async Task<ActionResult<ItemDataView>> GetItemData(int itemId, int itemDataId)
        {
            var itemDataView = await _itemRepository.GetItemDataViewById(itemId, itemDataId);

            if (itemDataView == null)
            {
                return NotFound();
            }

            return itemDataView;
        }

        // GET: api/Item/5/ItemText
        [HttpGet("{itemId}/ItemText", Name = "GetItemTexts")]
        public async Task<IEnumerable<ItemTextView>> GetItemTexts(int itemId)
        {
            var itemTextViews = await _itemRepository.GetItemTextViewsByItemId(itemId);

            return itemTextViews;
        }

        // GET: api/Item/5/ItemData
        [HttpGet("{itemId}/ItemData", Name = "GetItemDatas")]
        public async Task<IEnumerable<ItemDataView>> GetItemDatas(int itemId)
        {
            var itemDataViews = await _itemRepository.GetItemDataViewsByItemId(itemId);

            return itemDataViews;
        }

        // POST: api/Item/5/ItemAttribute
        [HttpPost("{itemId}/ItemAttribute")]
        public async Task<ActionResult<ItemDataView>> PostItemAttribute(int itemId, [FromBody] ItemAttributeView itemAttributeView)
        {
            try
            {
                itemAttributeView.ItemId = itemId;

                if (ModelState.IsValid)
                {
                    var createdeItemAttributeView = await _itemRepository.AddItemAttributeView(itemAttributeView);

                    return CreatedAtAction("Get", new { id = createdeItemAttributeView.ItemId }, createdeItemAttributeView);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to save the ItemAttribute: " + ex.Message);
            }
        }

        // GET: api/Item/5/ItemAttribute
        [HttpGet("{itemId}/ItemAttribute", Name = "GetItemAttributes")]
        public async Task<IEnumerable<ItemAttributeView>> GetItemAttributes(int itemId)
        {
            var itemAttributeViews = await _itemRepository.GetItemAttributeViewsByItemId(itemId);

            return itemAttributeViews;
        }

        // GET: api/Item/5/ItemAttribute/1
        [HttpGet("{itemId}/ItemAttribute/{itemAttributeId}", Name = "GetItemAttribute")]
        public async Task<ItemAttributeView> GetItemAttribute(int itemId, int itemAttributeId)
        {
            var itemAttributeView = await _itemRepository.GetItemAttributeViewByItemAttributeId(itemAttributeId);

            return itemAttributeView;
        }

        // DELETE: api/Item/5/ItemAttribute/1
        [HttpDelete("{itemId}/ItemAttribute/{itemAttributeId}", Name = "DeleteItemAttribute")]
        public async Task DeleteItemAttribute(int itemId, int itemAttributeId)
        {
            await _itemRepository.DeleteItemAttributeViewById(itemAttributeId);

        }

    }
}
