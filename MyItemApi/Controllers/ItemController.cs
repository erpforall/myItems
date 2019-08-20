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
        private readonly IRepository _repository;

        public ItemController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<IEnumerable<ItemView>> GetItems(int ownerId)
        {
            return await _repository.GetItemViewsByOwnerId(ownerId);
        }

        // GET: api/Item/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ItemView> Get(int id)
        {
            return await _repository.GetItemViewById(id);
        }

        // POST: api/Item
        [HttpPost]
        public async Task<ActionResult<ItemView>> Post([FromBody] ItemView itemView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdeItemView = await _repository.AddItemView(itemView);

                    return CreatedAtAction("Get", new { id = createdeItemView.ItemId }, createdeItemView);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch ( Exception ex)
            {

            }
            return BadRequest("Failed to save the Item");
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
    }
}
