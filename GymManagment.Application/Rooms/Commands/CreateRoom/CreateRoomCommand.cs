using ErrorOr;
using GymManagment.Domain.Rooms;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManagment.Application.Rooms.Commands.CreateRoom
{
    public record CreateRoomCommand(Guid GymId,
        string RoomName) : IRequest<ErrorOr<Room>>;
}
