using ErrorOr;
using MediatR;


namespace GymManagment.Application.Subsicriptions.Comands.DeleteSubscription;

public record DeleteSubscriptionCommand(Guid SubscriptionId)
    :IRequest<ErrorOr<Deleted>>;
