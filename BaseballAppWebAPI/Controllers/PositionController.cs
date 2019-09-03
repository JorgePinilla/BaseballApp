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
    public class PositionController : ControllerBase{
        private readonly IDBRepository _repo;
        private readonly IMapper _mapper;

        public PositionController(IDBRepository repo, IMapper mapper){
            _repo = repo;
            _mapper = mapper;
        }

        // GET api/position
        [HttpGet]
        public ActionResult<IEnumerable<PositionModel>> Get()
        {
            var positions = _repo.GetPositions();
            return Ok(Mapper.Map<IEnumerable<PositionModel>>(positions));
        }
    }
}