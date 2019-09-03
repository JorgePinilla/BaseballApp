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
    public class PeopleController : ControllerBase{
        private readonly IDBRepository _repo;
        private readonly IMapper _mapper;

        public PeopleController(IDBRepository repo, IMapper mapper){
            _repo = repo;
            _mapper = mapper;
        }

        // GET api/people
        [HttpGet]
        public ActionResult<IEnumerable<PersonModel>> Get()
        {
            var people = _repo.GetPeople();
            return Ok(Mapper.Map<IEnumerable<PersonModel>>(people));
        }

        // GET api/people/5
        [HttpGet("{id}")]
        public ActionResult<PersonModel> Get(int id)
        {
           var person = _repo.GetPerson(id);
           return Ok(Mapper.Map<PersonModel>(person));
        }

        // Get api/people/5/stats/hitting
        [HttpGet("{id}/stats/{statGroup}")]
        public ActionResult<IEnumerable<Stat>> GetStatsByGroup(int id, string statGroup){
            var stats = _repo.GetPlayerStatsByGroup(id, statGroup);
            return Ok(Mapper.Map<IEnumerable<Stat>>(stats));
        }
    }
}