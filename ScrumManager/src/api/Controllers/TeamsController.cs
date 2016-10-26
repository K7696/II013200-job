using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Model;
using CoreBusinessObjects;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    [Route("api/[controller]/{companyId}")]
    public class TeamsController : Controller
    {
        #region Fields

        private ApiContext context;

        #endregion // Fields

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="ctx"></param>
        public TeamsController(ApiContext ctx)
        {
            context = ctx;
        }

        #endregion // Constructors

        #region Private methods

        /// <summary>
        /// Get a team
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="teamId">Team Id</param>
        /// <returns>IQueryable</returns>
        private IQueryable<Team> getTeam(int companyId, int teamId)
        {
            var result = context.Teams
                .Where(x => x.CompanyId == companyId && x.TeamId == teamId);

            return result;
        }

        /// <summary>
        /// Map team properties for updating the team
        /// </summary>
        /// <param name="person">Team to update</param>
        /// <param name="value">Team with new values</param>
        private void mapTeamUpdate(Team team, Team value)
        {
            // Map properties
            team.Description = value.Description;
            team.Modified = DateTime.Now;
            team.ShortCode = value.ShortCode;
            team.Name = value.Name;
            team.ModifierId = value.ModifierId;
        }

        #endregion // Private methods

        #region Get methods

        // GET: api/teams/1
        /// <summary>
        /// Get teams
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <returns></returns>
        public IEnumerable<Team> Get(int companyId)
        {
            var result = context.Teams
                .Where(x => x.CompanyId == companyId)
                .ToList();

            return result;
        }

        // GET: api/teams/1/2
        /// <summary>
        /// Get a team and its persons
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <param name="personId">Team Id</param>
        /// <returns></returns>
        /// <statusCode="200">Ok</statusCode>
        /// <statusCode="400">Bad request</statusCode>
        /// <statusCode="404">Not found</statusCode>
        [HttpGet("{teamId}")]
        [Produces("application/json")]
        public IActionResult Get(int companyId, int teamId)
        {
            try
            {
                var result = context.Teams
                .Where(x => x.CompanyId == companyId && x.TeamId == teamId)
                .Include(p => p.Persons);

                var team = result.FirstOrDefault();

                if (team != null)
                    return Ok(team);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return NotFound();
        }

        #endregion // Get methods

        #region Data altering

        // POST: api/teams/1
        /// <summary>
        /// Add a new team
        /// </summary>
        /// <param name="companyid"></param>
        /// <param name="value"></param>
        /// <returns>Created entity</returns>
        /// <statusCode="200">Ok</statusCode>
        /// <statusCode="400">Bad request</statusCode>
        [HttpPost]
        public IActionResult Post(int companyid, [FromBody]Team value)
        {
            try
            {
                context.Teams.Add(value);
                context.SaveChanges();

                var result = getTeam(companyid, value.TeamId)
                    .FirstOrDefault();

                if (result != null)
                    return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return BadRequest();
        }

        // PUT: api/teams/1/2
        /// <summary>
        /// Update a team
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <param name="id">Team Id</param>
        /// <param name="value">Team entity</param>
        /// <returns>Updated entity</returns>
        /// <statusCode="200">Ok</statusCode>
        /// <statusCode="400">Bad request</statusCode>
        /// <statusCode="404">Not found</statusCode>
        [HttpPut("{id}")]
        public IActionResult PUT(int companyId, int id, [FromBody]Team value)
        {
            try
            {
                // This method is only for updating data
                if (id < 1)
                    return BadRequest();

                var result = getTeam(companyId, id)
                    .FirstOrDefault();

                if (result == null)
                    return NotFound();

                // Map person properties
                mapTeamUpdate(result, value);

                context.SaveChanges();

                var updatedResult = getTeam(companyId, id)
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

        // DELETE: api/teams/1/2
        /// <summary>
        /// Delete a team
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="id"></param>
        /// <returns>StatusCode</returns>
        /// <statusCode="200">Ok</statusCode>
        /// <statusCode="400">Bad request</statusCode>
        /// <statusCode="404">Not found</statusCode>
        [HttpDelete("{id}")]
        public IActionResult Delete(int companyId, int id)
        {
            try
            {
                var result = getTeam(companyId, id)
                    .FirstOrDefault();

                if (result == null)
                    return NotFound();

                context.Teams.Remove(result);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        #endregion // Data altering
    }
}
