using ErrorOr;
using GymManagment.Domain.Rooms;
using System;
using System.Collections.Generic;
using System.Text;
using Throw;

namespace GymManagment.Domain.Gyms
{
    public class Gym
    {
        private readonly int _maxRooms;
            public Guid Id { get; }

        public readonly List<Guid> _roomIds = [];
        public readonly List<Guid> _trainerIds = [];
        public string Name { get; init; }
        public Guid SubscriptionId { get; init; }

        public Gym(string name,int maxRooms,Guid subscriptionId,Guid? id = null)
        {
            Name = name;
            _maxRooms = maxRooms;
            SubscriptionId = subscriptionId;
            Id=id??Guid.NewGuid();
        }

        public ErrorOr<Success>AddRoom(Room room)
        {
            _roomIds.Throw().IfContains(room.Id);
            if(_roomIds.Count >= _maxRooms)
            {
                return GymErrors.CannotHaveMoreRoomsThanSubscriptionAllows;
            }

            _roomIds.Add(room.Id);
            return Result.Success;
        }

        bool HasRoom(Guid roomId)
        {
            return _roomIds.Contains(roomId);
        }

        public ErrorOr<Success>AddTrainer(Guid trainerId)
        {
            if (_trainerIds.Contains(trainerId))
            {
                return Error.Conflict(description: "Trainer already assigned to the gym.");
            }
            _trainerIds.Add(trainerId);
            return Result.Success;
        }

        public void RemoveRoom(Guid roomId)
        {
            _roomIds.Remove(roomId);
        }

        private Gym(){}

            
    }
}
