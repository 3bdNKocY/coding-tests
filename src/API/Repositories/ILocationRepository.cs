using API.Entities;

namespace API.Repositories
{
    /// <summary>
    /// Stores the current location and history of past locations.
    /// </summary>
    public interface ILocationRepository
    {
        /// <summary>
        /// Add a new position.
        /// </summary>
        void AddPosition(Position position);

        /// <summary>
        /// Returns the last location added.
        /// If no locations are added, this returns the default position of (0, 0, N).
        /// </summary>
        Position GetCurrentLocation();
    }
}