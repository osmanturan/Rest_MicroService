using System.Collections.Generic;
using Catalog.Service.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Catalog.Service.Repositories;
using System.Threading.Tasks;
using Catalog.Service.Entities;

namespace Catalog.Service.Controllers
{
    [ApiController]
    [Route("Items")]  // https(s):\\localhost:5000(5001)/Items
    public class ItemsController : ControllerBase
    {
        private readonly ItemsRepository itemsRepository = new();

        [HttpGet]
        public IEnumerable<ItemDataTransfer> Get()
        {
            var items = (itemsRepository.GetAll()).Select(item => item.AsDataTransfer());
            return items;
        }

        [HttpGet("{id}")]  // get /items/102030
        public ActionResult<ItemDataTransfer> GetById(Guid id)
        {
            var item = itemsRepository.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsDataTransfer();
        }


        [HttpPost]
        public ActionResult<ItemDataTransfer> Post(CreateItemDataTransfer createitem)
        {
            var item = new Item
            {
                Name = createitem.Name,
                Description = createitem.Description,
                Available = createitem.Available,
                Price = createitem.Price,
                AddingDate = DateTime.Now
            };

            itemsRepository.Create(item);

            // return CreatedAtAction takes 3 parameters. If we send parameters not equal 3 then we can use postasycs. 
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]  // // put /items/102030
        public IActionResult Put(Guid id, UpdateItemDataTransfer item)
        {
            // find the existing item
            var searchitem = itemsRepository.Get(id);

            if (searchitem == null)
            {
                return NotFound();
            }

            searchitem.Name = item.Name;
            searchitem.Description = item.Description;
            searchitem.Available = item.Available;
            searchitem.Price = item.Price;

            itemsRepository.Update(searchitem);

            return NoContent();
        }

        [HttpDelete("{id}")]  // // delete /items/102030
        public IActionResult Delete(Guid id)
        {
            itemsRepository.Delete(id);

            return NoContent();
        }
    }
}