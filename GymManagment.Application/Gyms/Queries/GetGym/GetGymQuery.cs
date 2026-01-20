using ErrorOr;
using GymManagment.Domain.Gyms;
using MediatR;

namespace GymManagment.Application.Gyms.Queries.GetGym;

public record GetGymQuery(Guid SubscriptionId, Guid GymId)
    :IRequest<ErrorOr<Gym>>;

