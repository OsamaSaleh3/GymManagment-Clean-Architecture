using ErrorOr;
using GymManagment.Domain.Subscriptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Subsicriptions.Comands.CreateSubsicription
{
    public record CreateSubscriptionCommand(string SubsicriptionType,Guid AdminId):IRequest<ErrorOr<Subscription>>;

}
