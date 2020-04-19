using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

using Otter.Core;
using Otter.Components.Controllers;

namespace Specs
{
    [TestClass]
    public class When_player1_uses_xbox_controller : with_valid_keys
    {
        private Game _game;

        public override void When()
        {
            _game = new Game("Specs.When_player1_uses_xbox_controller", 1, 1);
            _game.SetWindow(1, 1);
        }

        [TestMethod]
        public void Then_Dpad_Can_Be_Set()
        {
            using(_game)
            {
                _game.AddSession("Player1", new ControllerXbox360());
                var controller = _game.Session("Player1").Controller;

                controller.Enabled = true;
                controller.Enabled.Should().BeTrue();

                controller.Should().BeOfType(typeof(ControllerXbox360));
                controller.DPad.Should().NotBeNull();   // because this is a joystick

                Action act = () => controller.DPad.AddKeys(sut);
                act.Should().Throw<ArgumentException>()
                    .WithMessage("Must use four keys for an axis!");

                controller.DPad.AddKeys(new Key[] { Key.Up, Key.Down, Key.Left, Key.Right });
                sut.Length.Should().NotBe(controller.DPad.Keys.Count);
                controller.DPad.Keys.Count.Should().Be(9); // None, Left, DownLeft, UpLeft, etc...
            }
        }
    }
}
