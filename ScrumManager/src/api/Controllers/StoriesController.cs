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
    [Route("api/[controller]/{companyId}")]
    public class StoriesController : Controller
    {
        #region Fields

        private ApiContext context;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="ctx"></param>
        public StoriesController(ApiContext ctx)
        {
            context = ctx;
        }

        #endregion Constructors

        #region Get methods

        // GET: api/stories/1
        /// <summary>
        /// Get all stories
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <returns></returns>
        public IEnumerable<Story> Get(int companyId)
        {
            var result = context.Stories
                .Where(x => x.CompanyId == companyId)
                .ToList();

            return result;
        }

        #endregion Get methods
    }
}
