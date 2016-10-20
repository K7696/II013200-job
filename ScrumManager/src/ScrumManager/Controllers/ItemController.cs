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
        #region Fields

        private ApiClient<Item> apiClient;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public ItemController()
        {
            apiClient = new ApiClient<Item>();
        }

        #endregion // Constructors

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
                items = await apiClient.GetList(url);
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
                item = await apiClient.GetObject(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(item);
        }

        /// <summary>
        /// Save item details
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<JsonResult> SaveItemDetails(Item item)
        {
            try
            {
                string url = "http://localhost:50002/api/items/1/" + item.ItemId.ToString();
                item = await apiClient.PostObject(item, url, ApiHttpMethod.PUT);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(item);
        }
    }
}
