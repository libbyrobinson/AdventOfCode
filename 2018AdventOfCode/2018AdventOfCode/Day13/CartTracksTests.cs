using FluentAssertions;
using Xunit;

namespace _2018AdventOfCode.Day13
{
    public class CartTracksTests
    {
        [Fact]
        public void ShouldFindCrashLocationFromSmallExample()
        {
            var sut = new CartTracks(PuzzleInputParser.ParseStrings("Day13/SmallInput.txt"));
            var crash = sut.MoveCartsUntilCrash();
            crash.X.Should().Be(7);
            crash.Y.Should().Be(3);
        }

        [Fact]
        public void ShouldFindCrashLocationFromBigInput()
        {
            var sut = new CartTracks(PuzzleInputParser.ParseStrings("Day13/BigInput.txt"));
            var crash = sut.MoveCartsUntilCrash();
            crash.X.Should().Be(76);
            crash.Y.Should().Be(108);
        }

        [Fact]
        public void ShouldFindLastCarThatHasntCrashed()
        {
            var sut = new CartTracks(PuzzleInputParser.ParseStrings("Day13/BigInput.txt"));
            var cart = sut.MoveCartsUntilAllButOneHaveCrashed();
            cart.CurrentTrack.X.Should().Be(2);
            cart.CurrentTrack.Y.Should().Be(84);
        }
    }
}