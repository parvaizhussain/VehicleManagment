using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Application.Features.City.Queries.GetCityByID;
using Application.Features.City.Queries.GetCityList;
using Application.Features.City.Commands.CreateCity;
using Application.Features.City.Commands.UpdateCity;
using Application.Features.City.Commands.DeleteCity;
using Application.Features.City.Queries.GetCityByShortName;
using Application.Features.City.Queries.GetRegionCityByID;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly IMediator _mediator;
        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetCityById")]
        public async Task<ActionResult<GetCityVM>> GetCityById(int id)
        {
            var getCityQuery = new GetCityQuery() { CityId = id };
            return Ok(await _mediator.Send(getCityQuery));
        }

        [HttpGet("RegionId", Name = "GetCityByRegionId")]
        public async Task<ActionResult<List<GetCityVM>>> GetCityByRegionId(int id)
        {
            var getCityQuery = new GetRegionCityQuery() { RegionId = id };
            return Ok(await _mediator.Send(getCityQuery));
        }

        [HttpGet("ShortName", Name = "GetCityByShortName")]
        public async Task<ActionResult<GetCityVM>> GetCityByShortName(string ShortName)
        {
            var getCityQuery = new GetCityByShortNameQuery() { ShortName = ShortName };
            return Ok(await _mediator.Send(getCityQuery));
        }

        [HttpGet("all", Name = "GetAllCity")]
        public async Task<ActionResult<List<GetCityListVM>>> GetAllCity()
        {
            var dtos = await _mediator.Send(new GetCityListQuery());
            return Ok(dtos);
        }
        [HttpPost(Name = "AddCity")]
        public async Task<ActionResult<CreateCityCommandResponse>> Create([FromBody] CreateCityCommand createCityCommand)
        {
            var response = await _mediator.Send(createCityCommand);
            return Ok(response);                  
        }

        [HttpPatch(Name = "UpdateCity")]
        public async Task<ActionResult> Put([FromBody] UpdateCityCommand updateCityCommand)
        {
            var response = await _mediator.Send(updateCityCommand);
            return Ok(response);
        }

        [HttpPatch("DeleteCity", Name = "DeleteCityById")]
        public async Task<ActionResult<GetCityVM>> DeleteCityById([FromBody] DeleteCityCommand DeleteCityCommand)
        {
            var response = await _mediator.Send(DeleteCityCommand);
            return Ok(response);
        }


    }
}
