using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreBusinessObjects;
using ScrumManager.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ScrumManager.Controllers
{
    public class TeamController : Controller
    {
        #region Fields

        private ApiClient<Team> apiClient;
        private string url;

        #endregion // Fields

        #region Constructors

        public TeamController()
        {
            apiClient = new ApiClient<Team>();
            url = "http://localhost:50002/api/teams/1";
        }

        #endregion // Constructors

        #region Public JSON methods

        /// <summary>
        /// Get list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async System.Threading.Tasks.Task<JsonResult> GetList()
        {
            List<Team> list = new List<Team>();

            try
            {
                list = await apiClient.GetList(url);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(list);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async System.Threading.Tasks.Task<JsonResult> Get(int id)
        {
            Team obj = new Team();
            try
            {
                obj = await apiClient.GetObject(url + "/" + id.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(obj);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public async System.Threading.Tasks.Task<JsonResult> Update(Team obj)
        {
            try
            {
                obj = await apiClient.PostObject(obj, url + "/" + obj.TeamId.ToString(), ApiHttpMethod.PUT);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(obj);
        }

        /// <summary>
        /// Delete 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpDelete]
        public async System.Threading.Tasks.Task<JsonResult> Delete(Team obj)
        {
            try
            {
                obj = await apiClient.PostObject(obj, url + "/" + obj.TeamId.ToString(), ApiHttpMethod.DELETE);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Json(null);
        }

        #endregion // Public JSON methods
    }
}
