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
                game.SetWindowScale(3);
                game.Color = new Color("749ace");

                game.AddSession(players[0]);
                SetUpController(game.Session(players[0]).Controller);

                game.AddSession(players[1], new ControllerXbox360());
                SetUpController(game.Session(players[1]).Controller);

                game.AddSession(players[2], new ControllerPS3());
                SetUpController(game.Session(players[2]).Controller);

                game.Color = new Color(0.4f, 0.4f, 0.8f);

                var scene = new Scene();
                scene.Add(new Player1Entity(game.Session(players[0])));
                scene.Add(new Player2Entity(game.Session(players[1])));
                scene.Add(new Player3Entity(game.Session(players[2])));
                game.Start();
            }
        }

        private static void SetUpController(Controller controller, int? joyIndex=0) // need to test if index is needed
        {
            var isJoystick = (controller.GetType() == typeof(ControllerXbox360)
                || controller.GetType() == typeof(ControllerPS3));

            controller.Enabled = true;
            controller.AddButton("Action1");
            controller.AddButton("Action2");
            controller.AddButton("Up");
            controller.AddButton("Down");
            controller.AddButton("Left");
            controller.AddButton("Right");

            if (isJoystick)
            {
                controller.Button("Action1").AddJoyButton(0);  // 'A' on XBox, 'Triangle' on PS
                controller.Button("Action2").AddJoyButton(1);  // 'B' on XBox, 'Circle' on PS
                controller.Button("Up").AddAxisButton(AxisButton.YMinus).AddAxisButton(AxisButton.PovYMinus);
                controller.Button("Down").AddAxisButton(AxisButton.YPlus).AddAxisButton(AxisButton.PovYPlus);
                controller.Button("Left").AddAxisButton(AxisButton.XMinus).AddAxisButton(AxisButton.PovXMinus);
                controller.Button("Right").AddAxisButton(AxisButton.XPlus).AddAxisButton(AxisButton.PovXPlus);
            }
            else
            {
                controller.Button("Action1").AddKey(Key.X);
                controller.Button("Action2").AddKey(Key.C);
                controller.Button("Up").AddKey(Key.Up);
                controller.Button("Down").AddKey(Key.Down);
                controller.Button("Left").AddKey(Key.Left);
                controller.Button("Right").AddKey(Key.Right);
            }
        }
    }
}
