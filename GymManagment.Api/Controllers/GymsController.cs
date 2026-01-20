using GymManagment.Application.Gyms.Commands.AddTrainer;
using GymManagment.Application.Gyms.Commands.CreateGym;
using GymManagment.Application.Gyms.Commands.DeleteGym;
using GymManagment.Application.Gyms.Queries.GetGym;
using GymManagment.Application.Gyms.Queries.ListGyms;
using GymManagment.Contracts.Gyms;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymManagment.Api.Controllers
{
    [Route("subscriptions/{subscriptionId:guid}/gyms")]
    public class GymsController : ApiController
    {
        private readonly ISender _mediator;
        public GymsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGym(
              CreateGymRequest request,
              Guid subscriptionId)
        {
            var Command = new CreateGymCommand(request.Name, subscriptionId);
            var createGymResult = await _mediator.Send(Command);

            return createGymResult.Match(
           gym => CreatedAtAction(
               nameof(GetGym),
               new { subscriptionId, GymId = gym.Id },
               new GymResponse(gym.Id, gym.Name)),
           Problem);
        }


        [HttpDelete("{gymId:guid}")]
        public async Task<IActionResult> DeleteGym(Guid subscriptionId, Guid gymId)
        {
            var Command = new DeleteGymCommand(subscriptionId, gymId);

            var deleteGymResult = await _mediator.Send(Command);

            return deleteGymResult.Match(
           _ => NoContent(),
           Problem);

        }

        [HttpGet]
        public async Task<IActionResult> ListGyms(Guid subscriptionId)
        {
            var Query = new ListGymQuery(subscriptionId);
            var listGymResult = await _mediator.Send(Query);
            return listGymResult.Match(
                gyms => Ok(gyms.ConvertAll(g => new GymResponse(g.Id, g.Name)))
                ,
                Problem
                );
        }

        [HttpGet("{gymId:guid}")]
        public async Task<IActionResult> GetGym(Guid subscriptionId, Guid gymId)
        {
            var command = new GetGymQuery(subscriptionId, gymId);

            var getGymResult = await _mediator.Send(command);

            return getGymResult.Match(
                gym => Ok(new GymResponse(gym.Id, gym.Name)),
                Problem);
        }

        [HttpPost("{gymId:guid}/trainers")]
        public async Task<IActionResult> AddTrainer(AddTrainerRequest request, Guid subscriptionId, Guid gymId)
        {
            var Command = new AddTrainerCommand(subscriptionId, gymId, request.TrainerId);
            var addTrainerResult = await _mediator.Send(Command);

            return addTrainerResult.Match(
                success => Ok(),
                Problem
                );
        }
    }
}
