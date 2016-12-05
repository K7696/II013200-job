using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ScrumManager.Models;
using CoreBusinessObjects.Models;
using IdentityModel.Client;

namespace ScrumManager.Controllers
{
    public class HomeController : Controller
    {
        #region Fields

        #endregion Fields

        #region Constructors

        public HomeController()
        {

        }

        #endregion Constructors

        #region Public methods

        /// <summary>
        /// First method ever
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // return Redirect("~/Index/Developer/");
            return View();
        }

        /// <summary>
        /// Try login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            try
            {
                //var result = await client.GetObject(loginUrl + "/" + username + "/" + password);

                // discover endpoints from metadata
                var disco = await DiscoveryClient.GetAsync("http://localhost:50000");

                // request token
                var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
                var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("alice", "password", "api1");

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        #endregion Public methods
    }
}
