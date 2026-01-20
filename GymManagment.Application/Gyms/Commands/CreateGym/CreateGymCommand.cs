using ErrorOr;
using GymManagment.Domain.Gyms;
using MediatR;

namespace GymManagment.Application.Gyms.Commands.CreateGym;

public record CreateGymCommand(string Name,Guid SubscriptionId)
    :IRequest<ErrorOr<Gym>>;