using FluentAssertions;
using Flurl.Http;
using Xunit;

namespace API.E2ETests
{
    /// <summary>
    /// Please keep in mind that this test only succeeds once due to the current database implementation.
    /// Restart the service in order for the base position to reset.
    /// </summary>
    public class UpdatePositionTests
    {
        [Fact]
        public async void Endpoint_WhenCalledWithPdfExample_ReturnsCorrectPosition()
        {
            var endpoint = "https://localhost:5001/UpdatePosition";
            await $"{endpoint}?command=F".PostAsync();
            await $"{endpoint}?command=F".PostAsync();
            await $"{endpoint}?command=R".PostAsync();
            await $"{endpoint}?command=F".PostAsync();
            var response = await $"{endpoint}?command=F"
                .PostAsync()
                .ReceiveJson<RoverPosition>();

            response.Orientation.Should().Be(Orientation.E);
            response.NorthSouthPosition.Should().Be(2);
            response.WestEastPosition.Should().Be(2);
        }
    }

    internal class RoverPosition
    {
        public int NorthSouthPosition { get; set; }
        public int WestEastPosition { get; set; }
        public Orientation Orientation { get; set; }
    }

    internal enum Orientation
    {
        N,
        E,
        S,
        W,
    }
}
