using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CoreBusinessObjects.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ScrumManager.Controllers
{
    public class ItemController : Controller
    {
        /// <summary>
        /// Get items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetItems()
        {
            List<Item> items = new List<Item>();
            items.Add(new Item { ItemId = 1, Name = "Task 1" });
            items.Add(new Item { ItemId = 2, Name = "Task 2" });

            return Json(items);
        }

        /// <summary>
        /// Get single item details
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetItemDetails(int itemId)
        {
            Item item = new Item
            {
                ItemId = 1,
                Name = "Task 2"
            };

            return Json(item);
        }
    }
}
