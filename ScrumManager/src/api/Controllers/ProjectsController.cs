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
    public class ProjectsController : Controller
    {
        #region Fields

        private ApiContext context;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="apiCtx"></param>
        public ProjectsController(ApiContext ctx)
        {
            context = ctx;
        }

        #endregion Constructor

        #region Private methods

        /// <summary>
        /// Get single project
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <param name="projectId">Project Id</param>
        /// <returns></returns>
        private IQueryable<Project> getSingleProject(int companyId, int projectId)
        {
            var result = context.Projects
                .Where(x => x.CompanyId == companyId && x.ProjectId == projectId);

            return result;
        }

        /// <summary>
        /// Map project properties for updating the project
        /// </summary>
        /// <param name="item">Project to update</param>
        /// <param name="value">Project with new values</param>
        private void mapProjectUpdate(Project project, Project value)
        {
            project.Name = value.Name;
            project.ShortCode = value.ShortCode;
            project.StartDate = value.StartDate;
            project.Deadline = value.Deadline;
            project.Description = value.Description;
            project.Modified = DateTime.Now;
            project.ModifierId = value.ModifierId;
            project.ShortCode = value.ShortCode;
        }

        #endregion Private methods

        #region Get methods

        // GET: api/projects/1
        /// <summary>
        /// Get all projects
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Project> Get(int companyId)
        {
            var result = context.Projects
                .Where(x => x.CompanyId == companyId)
                .ToList();

            return result;
        }

        // GET: api/projects/5/1
        /// <summary>
        /// Get single project
        /// </summary>
        /// <param name="id">Project id</param>
        /// <returns>The entity</returns>
        /// <statusCode="200">Ok</statusCode>
        /// <statusCode="400">Bad request</statusCode>
        /// <statusCode="404">Not found</statusCode>
        [HttpGet("{id}")]
        public IActionResult Get(int companyId, int id)
        {
            try
            {
                var result = getSingleProject(companyId, id)
                    .FirstOrDefault();

                if (result != null)
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return NotFound();
        }

        #endregion Get methods

        #region Data altering

        // POST: api/project/5
        /// <summary>
        /// Add new project
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <param name="item">Item entity</param>
        /// <returns>The entity</returns>
        /// <statusCode="200">Ok</statusCode>
        /// <statusCode="400">Bad request</statusCode>
        [HttpPost]
        public IActionResult Post(int companyId, [FromBody]Project value)
        {
            try
            {
                context.Projects.Add(value);
                context.SaveChanges();

                int id = value.ProjectId;

                var result = getSingleProject(companyId, id)
                    .FirstOrDefault();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // PUT: api/projects/1/2
        /// <summary>
        /// Update a project
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <param name="id">Project Id</param>
        /// <param name="value">Project entity</param>
        /// <returns>Updated entity</returns>
        /// <statusCode="200">Ok</statusCode>
        /// <statusCode="400">Bad request</statusCode>
        /// <statusCode="404">Not found</statusCode>
        [HttpPut("{id}")]
        public IActionResult PUT(int companyId, int id, [FromBody]Project value)
        {
            try
            {
                // This method is only for updating data
                if (id < 1)
                    return BadRequest();

                var result = getSingleProject(companyId, id)
                    .FirstOrDefault();

                if (result == null)
                    return NotFound();

                // Map person properties
                mapProjectUpdate(result, value);

                context.SaveChanges();

                var updatedResult = getSingleProject(companyId, id)
                    .FirstOrDefault();

                if (updatedResult != null)
                    return Ok(updatedResult);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return BadRequest();
        }


        // DELETE: api/projects/1/3
        /// <summary>
        /// Delete a preoject
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <param name="id">Project Id</param>
        /// <returns>Statuscode</returns>
        /// <statusCode="200">Ok</statusCode>
        /// <statusCode="400">Bad request</statusCode>
        /// <statusCode="404">Not found</statusCode>
        [HttpDelete("{id}")]
        public IActionResult Delete(int companyId, int id)
        {
            try
            {
                var result = getSingleProject(companyId, id)
                    .FirstOrDefault();

                if (result == null)
                    return NotFound();

                context.Projects.Remove(result);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        #endregion Data altering
    }
}
