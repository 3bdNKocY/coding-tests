using API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly Stack<Position> _positions;
        public LocationRepository()
        {
            _positions = new Stack<Position>();
            _positions.Push(new Position(0, 0, Orientation.N));
        }

        public Task<Position> GetCurrentLocation()
        {
            return Task.FromResult(_positions.Peek());
        }

        public Task AddPosition(Position position)
        {
            _positions.Push(position);

            return Task.CompletedTask;
        }
    }
}
