using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

using Otter.Core;
using Otter.Components.Controllers;

namespace Specs
{
    [TestClass]
    public class When_player1_uses_keyboard : with_valid_keys
    {
        private Game _game;

        public override void When()
        {
            _game = new Game("Specs.When_player1_uses_keyboard", 1, 1);
            _game.SetWindow(1, 1);
        }

        [TestMethod]
        public void Then_Instance_Should_Not_Be_A_Joystick()
        {
            using(_game)
            {
                _game.AddSession("Player1");
                var controller = _game.Session("Player1").Controller;

                controller.Enabled = true;
                controller.Enabled.Should().BeTrue();

                controller.Should().BeOfType(typeof(Controller));
                controller.Should().NotBeOfType(typeof(ControllerXbox360));
                controller.Should().NotBeOfType(typeof(ControllerPS3));
                controller.DPad.Should().BeNull();   // because this is not a joystick
            }
        }
    }
}
