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
    public class VenuesController : ControllerBase{
        private readonly IDBRepository _repo;
        private readonly IMapper _mapper;

        public VenuesController(IDBRepository repo, IMapper mapper){
            _repo = repo;
            _mapper = mapper;
        }

        // GET api/venues
        [HttpGet]
        public ActionResult<IEnumerable<VenueModel>> Get()
        {
            var venues = _repo.GetVenues();
            return Ok(Mapper.Map<IEnumerable<VenueModel>>(venues));
        }

        // GET api/venues/5
        [HttpGet("{id}")]
        public ActionResult<VenueModel> Get(int id)
        {
           var venue = _repo.GetVenue(id);
           return Ok(Mapper.Map<VenueModel>(venue));
        }
    }
}