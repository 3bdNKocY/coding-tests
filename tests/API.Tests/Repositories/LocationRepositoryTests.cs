using API.Entities;
using API.Repositories;
using FluentAssertions;
using Xunit;

namespace API.Tests.Repositories
{
    public class LocationRepositoryTests
    {
        [Fact]
        public void Constructor_WhenCalled_InitializesCurrentPosition()
        {
            var sut = new LocationRepository();

            sut.GetCurrentLocation().NorthSouthPosition.Should().Be(0);
            sut.GetCurrentLocation().WestEastPosition.Should().Be(0);
            sut.GetCurrentLocation().Orientation.Should().Be(Orientation.N);
        }

        [Fact]
        public void GetCurrentLocation_WhenCalledAfterAddingPosition_ReturnsLatestPosition()
        {
            var sut = new LocationRepository();
            sut.AddPosition(new Position(11, 17, Orientation.E));
            sut.AddPosition(new Position(19, 1, Orientation.W));
            Position latestPosition = new Position(3, 7, Orientation.S);
            sut.AddPosition(latestPosition);

            sut.GetCurrentLocation().Should().Be(latestPosition);
        }
    }
}
