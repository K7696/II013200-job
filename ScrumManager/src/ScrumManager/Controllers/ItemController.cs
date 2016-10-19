using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CoreBusinessObjects.Models;
using System;
using ScrumManager.Models;

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
        public async System.Threading.Tasks.Task<JsonResult> GetItems()
        {
            List<Item> items = new List<Item>();

            try
            {
                string url = "http://localhost:50002/api/items/1";
                ApiClient<Item> api = new ApiClient<Item>();
                items = await api.GetList(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(items);
        }

        /// <summary>
        /// Get single item details
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet]
        public async System.Threading.Tasks.Task<JsonResult> GetItemDetails(int itemId)
        {
            Item item = new Item();
            try
            {
                string url = "http://localhost:50002/api/items/1/" + itemId.ToString();
                ApiClient<Item> api = new ApiClient<Item>();
                item = await api.GetObject(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(item);
        }
    }
}
