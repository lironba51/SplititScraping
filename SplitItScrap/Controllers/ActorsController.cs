using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SplitItScrap.Domain.ErrorHandlers.Actors;
using SplitItScrap.Domain.Services.Actors;
using SplitItScrap.Domain.Services.Actors.Entities;
using SplitItScrap.Domain.Services.Actors.Queries;
using SplitItScrap.Models.Actors;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks;

namespace SplitItScrap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly IActorsService _actorsService;
        private readonly IMapper _mapper;
        public ActorsController(IActorsService actorsService, IMapper mapper)
        {
            _actorsService = actorsService;
            _mapper = mapper;
        }

        [HttpGet("actors")]
        public async Task<IActionResult> GetActorsAsync([FromQuery]ActorModelQuery actorModelQuery)
        {
            var actorQuery = _mapper.Map<ActorQuery>(actorModelQuery);
            var actors = await _actorsService.GetActorsAsync(actorQuery);
            var actorModelLstViews = _mapper.Map<List<ActorModelLstView>>(actors);

            return Ok(actorModelLstViews);
        }

        [HttpGet("actor/{id}")]
        public async Task<IActionResult> GetActorAsync([FromRoute] Guid id)
        {
            ActorModelView actorModelView;
            try
            {
                var actor = await _actorsService.GetActorAsync(id);
                actorModelView = _mapper.Map<ActorModelView>(actor);
            }
            catch (ActorNotFoundException actorNotFoundException)
            {
                return NotFound(actorNotFoundException);
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(actorModelView);
        }

        [HttpPost("actors")]
        public async Task<IActionResult> AddActorAsync([FromBody] ActorModelView actorModelQuery)
        {
            var actor = _mapper.Map<Actor>(actorModelQuery);
            await _actorsService.AddActorAsync(actor);

            return Ok();
        }

        [HttpPut("actors")]
        public async Task<IActionResult> UpdateActorAsync([FromBody] ActorModelView actorModelQuery)
        {
            var actor = _mapper.Map<Actor>(actorModelQuery);
            await _actorsService.UpdateActorAsync(actor);

            return Ok();
        }

        [HttpDelete("actors/{id}")]
        public async Task<IActionResult> DeleteActorAsync([FromRoute] Guid id)
        {
            await _actorsService.DeleteActorAsync(id);

            return Ok();
        }
    }
}
