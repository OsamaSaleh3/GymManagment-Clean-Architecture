using ErrorOr;
using GymManagment.Application.Subsicriptions.Comands.CreateSubsicription;
using GymManagment.Application.Subsicriptions.Queries.GetSubscription;
using GymManagment.Contracts.Subsicription;
using GymManagment.Domain.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainSubscriptionType = GymManagment.Domain.Subscriptions.SubscriptionType;
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
        public async Task<IActionResult> CreateSubsicription(CreatesubscriptionRequest request)
        {
            if (!DomainSubscriptionType.TryFromName(
            request.subsicriptionType.ToString(),
            out var subscriptionType))
            {
                return Problem(
                    statusCode: StatusCodes.Status400BadRequest,
                    detail: "Invalid Subscription Type");
            }
            var command = new CreateSubscriptionCommand(
            subscriptionType, 
            request.AdminId
        );

            var createSubsicriptionResult=await _mediator.Send(command);

            return createSubsicriptionResult.MatchFirst(
                subsicription => Ok(new SubscriptionResponse(subsicription.Id, request.subsicriptionType)),
                error => Problem());
        }

        [HttpGet]
        public async Task<IActionResult>GetSubscription(Guid subscriptionId)
        {
            var query = new GetSubscriptionQuery(subscriptionId);
            var getSubscriptionResult = await _mediator.Send(query);
            return getSubscriptionResult.MatchFirst(
                subscription=>Ok(new SubscriptionResponse(
                    subscription.Id,
                Enum.Parse<Contracts.Subsicription.SubscriptionType>(
                    subscription.SubscriptionType.Name
                ))),
                Error=> Problem());
        }
    }
}
