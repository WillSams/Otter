using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Specs
{
    [TestClass]
    public class When_you_write_specs_follow_this_coventions
    {
        readonly int firstValue = 1;
        int secondValue = 0;

        readonly bool youDidIt = true;

        [TestInitialize]
        public void When()
        {
            secondValue = firstValue + firstValue;
        }

        [TestMethod]
        public void Then_1_Plus_1_Should_Equal_Two()
        {
            secondValue.Should().Be(2);
            youDidIt.Should().BeTrue();
        }
    }
}
