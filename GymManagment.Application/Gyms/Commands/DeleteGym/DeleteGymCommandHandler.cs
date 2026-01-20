using ErrorOr;
using GymManagment.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Gyms.Commands.DeleteGym
{
    public class DeleteGymCommandHandler : IRequestHandler<DeleteGymCommand, ErrorOr<Deleted>>
    {
        private readonly ISubsicriptionsRepository _subscriptionReposiory;
        private readonly IGymsRepository _gymRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGymCommandHandler(IUnitOfWork unitOfWork, IGymsRepository gymRepository, ISubsicriptionsRepository subscriptionReposiory)
        {
            _unitOfWork = unitOfWork;
            _gymRepository = gymRepository;
            _subscriptionReposiory = subscriptionReposiory;
        }

        public async Task<ErrorOr<Deleted>> Handle(DeleteGymCommand request, CancellationToken cancellationToken)
        {
            var gym=await _gymRepository.GetByIdAsync(request.GymId);
            if(gym is null)
            {
                return Error.NotFound(description: "Gym not found");
            }
            var subscription = await _subscriptionReposiory.GetByIdAsync(gym.SubscriptionId);
            if (subscription is null)
            {
                return Error.NotFound(description: "Subscription not found");
            }
            if (!subscription.HasGym(gym.Id))
            {
                return Error.Unexpected(description: "Gym not found");
            }

            subscription.RemoveGym(gym.Id);
            await _subscriptionReposiory.UpdateAsync(subscription);
            await _gymRepository.RemoveGymAsync(gym);
            await _unitOfWork.CommitChangesAsync();

            return Result.Deleted;

        }
    }
}
