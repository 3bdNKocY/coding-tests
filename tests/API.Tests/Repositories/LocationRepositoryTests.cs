using API.Entities;
using API.Repositories;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace API.Tests.Repositories
{
    public class LocationRepositoryTests
    {
        [Fact]
        public async Task Constructor_WhenCalled_InitializesCurrentPosition()
        {
            var sut = new LocationRepository();

            var currentLocation = await sut.GetCurrentLocation();

            currentLocation.NorthSouthPosition.Should().Be(0);
            currentLocation.WestEastPosition.Should().Be(0);
            currentLocation.Orientation.Should().Be(Orientation.N);
        }

        [Fact]
        public async Task GetCurrentLocation_WhenCalledAfterAddingPosition_ReturnsLatestPosition()
        {
            var sut = new LocationRepository();
            await sut.AddPosition(new Position(11, 17, Orientation.E));
            await sut.AddPosition(new Position(19, 1, Orientation.W));
            Position latestPosition = new Position(3, 7, Orientation.S);
            await sut.AddPosition(latestPosition);

            var currentPosition = await sut.GetCurrentLocation();
            currentPosition.Should().Be(latestPosition);
        }
    }
}
