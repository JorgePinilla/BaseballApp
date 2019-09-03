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
    public class DivisionsController : ControllerBase{
        private readonly IDBRepository _repo;
        private readonly IMapper _mapper;

        public DivisionsController(IDBRepository repo, IMapper mapper){
            _repo = repo;
            _mapper = mapper;
        }

        // GET api/divisions
        [HttpGet]
        public ActionResult<IEnumerable<DivisionModel>> Get()
        {
            var divisions = _repo.GetDivisions();
            return Ok(Mapper.Map<IEnumerable<DivisionModel>>(divisions));
        }
    }
}