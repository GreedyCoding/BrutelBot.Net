using System;
using Xunit;

namespace DiscordBotCore.xUnit.Tests
{
    public class UtilityTests
    {
        [Fact]
        public static void XUnitTest()
        {
            const int expected = 5;

            var actual = Utilities.ReturnInt(expected);

            Assert.Equal(expected, actual);
        }
    }
}
