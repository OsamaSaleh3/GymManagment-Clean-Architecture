using ErrorOr;
using GymManagment.Domain.Gyms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Gyms.Queries.ListGyms;

public record ListGymQuery(Guid SubscriptionId)
: IRequest<ErrorOr<List<Gym>>>;
