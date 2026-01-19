using ErrorOr;
using GymManagment.Domain.Subscriptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Subsicriptions.Comands.CreateSubsicription
{
    public record CreateSubscriptionCommand(SubscriptionType SubsicriptionType,Guid AdminId):IRequest<ErrorOr<Subscription>>;

}
