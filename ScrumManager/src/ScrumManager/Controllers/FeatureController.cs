﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScrumManager.Models;
using CoreBusinessObjects.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ScrumManager.Controllers
{
    public class FeatureController : Controller
    {
        #region Fields

        private ApiClient<Feature> apiClient;
        private string url;

        #endregion // Fields

        #region Constructors

        public FeatureController()
        {
            apiClient = new ApiClient<Feature>();
            url = "http://localhost:50002/api/features/1";
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
            List<Feature> list = new List<Feature>();

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
            Feature obj = new Feature();
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
        public async System.Threading.Tasks.Task<JsonResult> Update(Feature obj)
        {
            try
            {
                obj = await apiClient.PostObject(obj, url + "/" + obj.FeatureId.ToString(), ApiHttpMethod.PUT);
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
        public async System.Threading.Tasks.Task<JsonResult> Delete(Feature obj)
        {
            try
            {
                obj = await apiClient.PostObject(obj, url + "/" + obj.FeatureId.ToString(), ApiHttpMethod.DELETE);
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
