using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Model;
using CoreBusinessObjects.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {

        #region Fields

        private ApiContext apiContext;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="apiCtx"></param>
        public ItemController(ApiContext apiCtx)
        {
            apiContext = apiCtx;
        }

        #endregion // Constructor

        #region Private methods

        /// <summary>
        /// Get single item
        /// </summary>
        /// <param name="itemId">Item Id</param>
        /// <returns></returns>
        private IQueryable<Item> getSingleItem(int itemId)
        {
            var result = apiContext.Items
                .Where(x => x.ItemId == itemId);

            return result;
        }

        #endregion // Private methods

        #region Get methods

        // GET: api/values
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            var result = apiContext.Items.ToList();

            return result;
        }

        // GET: api/item/5
        /// <summary>
        /// Get single item
        /// </summary>
        /// <param name="id">Item id</param>
        /// <returns>The item entity</returns>
        /// <statusCode="200">Ok</statusCode>
        /// <statusCode="400">Bad request</statusCode>
        /// <statusCode="404">Not found</statusCode>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = getSingleItem(id).FirstOrDefault();

                if (result != null)
                    return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }


            return NotFound();
        }


        #endregion // Get methods

        #region Data altering

        // POST: api/item/5
        /// <summary>
        /// Add new item
        /// </summary>
        /// <param name="item">Item entity</param>
        /// <returns>Item entity</returns>
        /// <statusCode="200">Ok</statusCode>
        /// <statusCode="400">Bad request</statusCode>
        [HttpPost]
        public IActionResult Post([FromBody]Item value)
        {
            try
            {
                apiContext.Items.Add(value);
                apiContext.SaveChanges();

                int id = value.ItemId;

                var result = getSingleItem(id).FirstOrDefault();

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }           
        }

        // DELETE: api/item/5
        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id">Item Id</param>
        /// <returns>Statuscode</returns>
        /// <statusCode="200">Ok</statusCode>
        /// <statusCode="400">Bad request</statusCode>
        /// <statusCode="404">Not found</statusCode>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = getSingleItem(id).FirstOrDefault();

                if (result == null)
                    return NotFound();

                apiContext.Items.Remove(result);
                apiContext.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
            return Ok();
        }

        #endregion // Data altering        
    }
}
