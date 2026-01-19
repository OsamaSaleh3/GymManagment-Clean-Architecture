using GymManagment.Contracts.Subsicription;
using GymManagment.Application.Subsicriptions.Comands.CreateSubsicription;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GymManagment.Domain.Subscriptions;
using ErrorOr;

namespace GymManagment.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubsicriptionController : ControllerBase
    {

        private readonly ISender _mediator;

        public SubsicriptionController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubsicription(CreatesubsicriptionRequest request)
        {
            var command = new CreateSubscriptionCommand(
            request.subsicriptionType.ToString(), 
            request.AdminId
        );

            var createSubsicriptionResult=await _mediator.Send(command);

            return createSubsicriptionResult.MatchFirst(
                subsicription => Ok(new SubsicriptionResponse(subsicription.Id, request.subsicriptionType)),
                error => Problem());
        }
    }
}
