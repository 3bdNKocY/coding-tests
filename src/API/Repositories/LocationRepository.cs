using API.Entities;
using System.Collections.Generic;

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

        public Position GetCurrentLocation()
        {
            return _positions.Peek();
        }

        public void AddPosition(Position position)
        {
            _positions.Push(position);
        }
    }
}
