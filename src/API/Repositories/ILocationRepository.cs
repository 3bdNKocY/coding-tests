using API.Entities;
using System.Threading.Tasks;

namespace API.Repositories
{
    /// <summary>
    /// Stores the current location and history of past locations.
    /// </summary>
    public interface ILocationRepository
    {
        /// <summary>
        /// Returns the last location added.
        /// If no locations are added, this returns the default position of (0, 0, N).
        /// </summary>
        Task<Position> GetCurrentLocation();

        /// <summary>
        /// Add a new position.
        /// </summary>
        Task AddPosition(Position position);
    }
}