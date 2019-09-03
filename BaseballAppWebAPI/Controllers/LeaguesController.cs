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
    public class LeaguesController : ControllerBase{
        private readonly IDBRepository _repo;
        private readonly IMapper _mapper;

        public LeaguesController(IDBRepository repo, IMapper mapper){
            _repo = repo;
            _mapper = mapper;
        }

        // GET api/leagues
        [HttpGet]
        public ActionResult<IEnumerable<LeagueModel>> Get()
        {
            var leagues = _repo.GetLeagues();
            return Ok(Mapper.Map<IEnumerable<LeagueModel>>(leagues));
        }

        // GET api/leagues/regular
        // GET api/leagues/spring
        [HttpGet("{type}")]
        public ActionResult<IEnumerable<LeagueModel>> Get(string type)
        {
            if(type == "spring"){
                var springLeagues = _repo.GetSpringLeagues();
                return Ok(Mapper.Map<IEnumerable<LeagueModel>>(springLeagues));
            }

            var leagues = _repo.GetRegularLeagues();
            return Ok(Mapper.Map<IEnumerable<LeagueModel>>(leagues));
        }
    }
}
