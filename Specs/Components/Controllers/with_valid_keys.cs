
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Otter.Core;

namespace Specs
{
    public abstract class with_valid_keys
    {
        [TestInitialize]
        public void SetUp()
        {
            sut = new Key[] { Key.Up, Key.Right, Key.Down, Key.Left,
                    Key.F1, Key.F2, Key.F3, Key.F4, Key.F5, Key.F6, Key.F7, Key.F8, Key.F9, Key.F10,
                    Key.F11, Key.F12, Key.LAlt, Key.RAlt, Key.LShift, Key.RShift, Key.Delete, Key.Escape,
                    Key.Insert, Key.Return, Key.Num0, Key.Num1, Key.Num2, Key.Num3, Key.Num4, Key.Num5,
                    Key.Num6, Key.Num7, Key.Num8, Key.Num9, Key.Multiply, Key.Divide, Key.Add,
                    Key.Subtract, Key.Equal, Key.Tilde, Key.Tab, Key.Comma, Key.SemiColon, Key.Space,
                    Key.Slash, Key.BackSlash, Key.Home, Key.End, Key.A, Key.B, Key.C, Key.D, Key.E, Key.F,
                    Key.G, Key.H, Key.I, Key.J, Key.K, Key.L, Key.M, Key.N, Key.O, Key.P, Key.Q, Key.R,
                    Key.S, Key.T, Key.U, Key.W, Key.X, Key.Y, Key.Z, Key.Dash, Key.LBracket, Key.RBracket,
                    Key.Pause, Key.LControl, Key.RControl, Key.LSystem, Key.RSystem, Key.Period,
                    Key.PageDown, Key.PageUp, Key.Any
                };
            When();
        }

        public Key[] sut { get; set; }

        public abstract void When();
    }
}
