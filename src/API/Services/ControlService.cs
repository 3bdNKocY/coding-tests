using API.Entities;
using API.Repositories;
using API.Requests;
using System.Threading.Tasks;

namespace API.Services
{
    public class ControlService : IControlService
    {
        private readonly ILocationRepository _repository;

        public ControlService(ILocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Position> ProcessCommand(Command command)
        {
            var currentLocation = await _repository.GetCurrentLocation();

            var orientation = GetOrientation(command, currentLocation.Orientation);
            var newPosition = GetPosition(command, orientation, currentLocation);

            await _repository.AddPosition(newPosition);

            return newPosition;
        }

        private static Orientation GetOrientation(Command command, Orientation orientation)
        {
            if (command == Command.F || command == Command.B)
            {
                return orientation;
            }

            return orientation switch
            {
                Orientation.N => command == Command.L ? Orientation.W : Orientation.E,
                Orientation.E => command == Command.L ? Orientation.N : Orientation.S,
                Orientation.S => command == Command.L ? Orientation.E : Orientation.W,
                Orientation.W => command == Command.L ? Orientation.S : Orientation.N,
                // Should not be hit unless there are more orientations available
                _ => orientation,
            };
        }

        private static Position GetPosition(Command command, Orientation orientation, Position position)
        {
            var movement = command switch
            {
                Command.F => 1,
                Command.B => -1,
                _ => 0,
            };

            var isNorthSouth = orientation == Orientation.N || orientation == Orientation.S;

            return new Position(
                isNorthSouth ? position.NorthSouthPosition + movement : position.NorthSouthPosition,
                !isNorthSouth ? position.WestEastPosition + movement : position.WestEastPosition,
                orientation);

        }
    }
}
