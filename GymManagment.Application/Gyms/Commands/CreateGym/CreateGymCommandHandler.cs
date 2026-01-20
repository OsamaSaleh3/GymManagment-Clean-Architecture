using ErrorOr;
using GymManagment.Application.Common.Interfaces;
using GymManagment.Domain.Gyms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Gyms.Commands.CreateGym
{
    public class CreateGymCommandHandler : IRequestHandler<CreateGymCommand, ErrorOr<Gym>>
    {
        private readonly ISubsicriptionsRepository _SubsicriptionRepository;
        private readonly IGymsRepository _gymRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateGymCommandHandler(ISubsicriptionsRepository subsicriptionRepository, IUnitOfWork unitOfWork, IGymsRepository gymRepository)
        {
            _SubsicriptionRepository = subsicriptionRepository;
            _unitOfWork = unitOfWork;
            _gymRepository = gymRepository;
        }


        public async Task<ErrorOr<Gym>> Handle(CreateGymCommand Command, CancellationToken cancellationToken)
        {
           var subsicription =await _SubsicriptionRepository.GetByIdAsync(Command.SubscriptionId);

            if (subsicription is null)
            {
                return Error.NotFound(description: "Subsicription not found");
            }

            var gym = new Gym(Command.Name, subsicription.GetMaxRooms(), subsicription.Id);
            var addGymResult=subsicription.AddGym(gym);
            if (addGymResult.IsError)
            {
                return addGymResult.Errors;
            }
            await _SubsicriptionRepository.UpdateAsync(subsicription);
            await _gymRepository.AddGymAsync(gym);
            await _unitOfWork.CommitChangesAsync();

            return gym;

        }
    }
}
