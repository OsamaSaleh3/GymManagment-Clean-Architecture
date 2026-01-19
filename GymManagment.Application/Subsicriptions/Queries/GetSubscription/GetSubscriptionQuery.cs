using ErrorOr;
using GymManagment.Domain.Subscriptions;
using MediatR;

namespace GymManagment.Application.Subsicriptions.Queries.GetSubscription;

public record GetSubscriptionQuery(Guid SubscriptionId) : IRequest<ErrorOr<Subscription>>;
