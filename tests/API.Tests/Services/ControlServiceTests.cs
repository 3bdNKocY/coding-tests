using API.Entities;
using API.Repositories;
using API.Requests;
using API.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace API.Tests.Services
{
    public class ControlServiceTests
    {
        [Fact]
        public async Task ProcessCommand_WhenCalled_RepositoryIsCalled()
        {
            var sut = new Mocker<ControlService>();
            sut.Obtain<ILocationRepository>()
                .Setup(lr => lr.GetCurrentLocation())
                .ReturnsAsync(new Position(0, 0, Orientation.N));

            await sut.Object.ProcessCommand(Command.F);

            sut.Obtain<ILocationRepository>()
                .Verify(lr => lr.AddPosition(It.IsAny<Position>()), Times.Once);
        }

        [Theory]
        [InlineData(Command.F, 1, 0, Orientation.N)]
        [InlineData(Command.B, -1, 0, Orientation.N)]
        [InlineData(Command.L, 0, 0, Orientation.W)]
        [InlineData(Command.R, 0, 0, Orientation.E)]
        public async Task ProcessCommand_WhenCalledWithCommand_ProcessesCorrectly(Command command, int northSouthPosition, int westEastPosition, Orientation orientation)
        {
            var sut = new Mocker<ControlService>();
            sut.Obtain<ILocationRepository>()
                .Setup(lr => lr.GetCurrentLocation())
                .ReturnsAsync(new Position(0, 0, Orientation.N));

            await sut.Object.ProcessCommand(command);

            sut.Obtain<ILocationRepository>()
                .Verify(lr => lr
                    .AddPosition(It.Is<Position>(p => 
                        p.NorthSouthPosition == northSouthPosition
                        && p.WestEastPosition == westEastPosition
                        && p.Orientation == orientation)), Times.Once);
        }
    }
}
