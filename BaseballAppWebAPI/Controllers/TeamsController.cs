using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace BaseballApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase{
        private readonly IDBRepository _repo;
        private readonly IMapper _mapper;

        public TeamsController(IDBRepository repo, IMapper mapper){
            _repo = repo;
            _mapper = mapper;
        }

        // GET api/teams
        [HttpGet]
        public ActionResult<IEnumerable<TeamModel>> Get()
        {
            var teams = _repo.GetTeams();
            return Ok(Mapper.Map<IEnumerable<TeamModel>>(teams));
        }

        // GET api/teams/112
        [HttpGet("{id}")]
        public ActionResult<TeamModel> Get(int id)
        {
           var team = _repo.GetTeam(id);
           return Ok(Mapper.Map<TeamModel>(team));
        }

        [HttpGet("{id}/roster")]
        public ActionResult<IEnumerable<RosterModel>> GetRoster(int id)
        {
            var roster = _repo.GetRoster(id);
            return Ok(Mapper.Map<IEnumerable<RosterModel>>(roster));
        }
    }
}