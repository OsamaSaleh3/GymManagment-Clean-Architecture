using ErrorOr;
using MediatR;

namespace GymManagment.Application.Gyms.Commands.DeleteGym;

public record DeleteGymCommand(Guid GymId) : IRequest<ErrorOr<Deleted>>;

