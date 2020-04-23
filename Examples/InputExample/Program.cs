using Otter.Core;
using Otter.Components.Controllers;
using Otter.Graphics;

namespace InputExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var players = new string[] { "Player 1", "Player 2", "Player 3" };

            using(var game = new Game("Input Example"))
            {
                game.Color = new Color("749ace");

                game.AddSession(players[0]);
                SetUpController(game.Session(players[0]).Controller);

                game.AddSession(players[1], new ControllerXbox360());
                SetUpController(game.Session(players[1]).Controller);

                game.AddSession(players[2], new ControllerPS3());
                SetUpController(game.Session(players[2]).Controller);

                //game.FirstScene = new GameScene();
                game.Start();
            }
        }

        private static void SetUpController(Controller controller, int? joyIndex=0) // need to test if index is needed
        {
            var isJoystick = (controller.GetType() == typeof(ControllerXbox360)
                || controller.GetType() == typeof(ControllerPS3));

            controller.Enabled = true;
            controller.AddButton("X");
            controller.AddButton("Start");
            controller.AddButton("Up");
            controller.AddButton("Down");
            controller.AddButton("Left");
            controller.AddButton("Right");

            if (isJoystick)
            {
                controller.Button("X").AddJoyButton(0);  // 'A' on XBox, 'Triangle' on PS
                controller.Button("Start").AddJoyButton(7);   // 'Start' on XBox, 'R1' on PS
                controller.Button("Up").AddAxisButton(AxisButton.YMinus).AddAxisButton(AxisButton.PovYMinus);
                controller.Button("Down").AddAxisButton(AxisButton.YPlus).AddAxisButton(AxisButton.PovYPlus);
                controller.Button("Left").AddAxisButton(AxisButton.XMinus).AddAxisButton(AxisButton.PovXMinus);
                controller.Button("Right").AddAxisButton(AxisButton.XPlus).AddAxisButton(AxisButton.PovXPlus);
            }
            else
            {
                controller.Button("X").AddKey(Key.X);
                controller.Button("Start").AddKey(Key.Return);
                controller.Button("Up").AddKey(Key.Up);
                controller.Button("Down").AddKey(Key.Down);
                controller.Button("Left").AddKey(Key.Left);
                controller.Button("Right").AddKey(Key.Right);
            }
        }
    }
}
