using ErrorOr;
using GymManagment.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Gyms.Commands.AddTrainer
{
    public class AddTrainerCommandHandler : IRequestHandler<AddTrainerCommand, ErrorOr<Success>>
    {
        private readonly IGymsRepository _gymRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddTrainerCommandHandler(IUnitOfWork unitOfWork, IGymsRepository gymRepository)
        {
            _unitOfWork = unitOfWork;
            _gymRepository = gymRepository;
        }

        public async Task<ErrorOr<Success>> Handle(AddTrainerCommand Command, CancellationToken cancellationToken)
        {
            var gym=await _gymRepository.GetByIdAsync(Command.GymId);
            if (gym == null)
            {
                return Error.NotFound(description: "Gym not found.");
            }
            var addTrainerResult = gym.AddTrainer(Command.TrainerId);
            if (addTrainerResult.IsError)
            {
                return addTrainerResult.Errors;
            }

            await _gymRepository.UpdateGymAsync(gym);
            await _unitOfWork.CommitChangesAsync();
            return Result.Success;
        }
    }
}
