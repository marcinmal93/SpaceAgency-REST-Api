using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using AutoMapper;
using SpaceAgency.App_Start;
using SpaceAgency.Dtos;
using SpaceAgency.Models;

namespace SpaceAgency.Controllers.Api
{
    [BasicAuthentication(Roles = Role.ProductContentAdministrator)]
    public class MissionsController : ApiController
    {
        private ApplicationDbContext _context;

        public MissionsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/missions
        public IEnumerable<Mission> GetMissions()
        {
            return _context.Missions.Include(m => m.MissionType).ToList();
        }

        // GET api/missions/id
        public IHttpActionResult GetMission(int id)
        {
            var mission = _context.Missions.Include(m => m.MissionType).SingleOrDefault(m => m.Id == id);

            if (mission == null)
                return NotFound();

            return Ok(mission);
        }

        // POST /api/missions
        [HttpPost]
        public IHttpActionResult AddMission(MissionDto missionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var mission = Mapper.Map<MissionDto, Mission>(missionDto);
            _context.Missions.Add(mission);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + mission.Id), missionDto);
        }

        // PUT api/missions/id
        [HttpPut]
        public void UpdateMission(int id, MissionDto missionDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var missionInDb = _context.Missions.SingleOrDefault(m => m.Id == id);

            if (missionInDb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Mapper.Map(missionDto, missionInDb);

            _context.SaveChanges();
        }

        // DELETE api/missions/id
        [HttpDelete]
        public void DeleteMission(int id)
        {
            var mission = _context.Missions.SingleOrDefault(m => m.Id == id);

            if (mission == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Missions.Remove(mission);
            _context.SaveChanges();
        }

    }
}
