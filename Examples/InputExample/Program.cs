using Otter.Core;
using Otter.Components.Controllers;
using Otter.Graphics;

namespace InputExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerSessionName = "Player 1";

            using(var game = new Game("Input Example"))
            {
                game.Color = new Color("749ace");

                game.AddSession(playerSessionName);
                SetupController(game.Session(playerSessionName).Controller);

                //game.FirstScene = new GameScene();
                game.Start();
            }
        }

        static void SetupController(Controller controller)
        {
            var isJoystick = (controller.GetType() == typeof(ControllerXbox360)
                || controller.GetType() == typeof(ControllerPS3));

            controller.Enabled = true;
            controller.AddButton("Action");
            controller.AddButton("Up");
            controller.AddButton("Down");
            controller.AddButton("Left");
            controller.AddButton("Right");
            controller.AddButton("Start");

            if (isJoystick)
            {
                //Leftstick/Motion
                controller.DPad.AddAxis(controller.LeftStick);
                controller.DPad.AddKeys(new Key[] { Key.Up, Key.Down, Key.Left, Key.Right });

                controller.Button("Action").AddJoyButton(0);  // 'A' on XBox, 'Triangle' on PS
                controller.Button("Up").AddJoyButton(16);     // Need to test on PS
                controller.Button("Down").AddJoyButton(17);   // Need to test on PS
                controller.Button("Left").AddJoyButton(18);   // Need to test on PS
                controller.Button("Right").AddJoyButton(19);  // Need to test on PS
                controller.Button("Start").AddJoyButton(7);   // 'Start' on XBox, 'R1' on PS
            }
            else
            {
                controller.Button("Action").AddKey(Key.Space);
                controller.Button("Up").AddKey(Key.Up);
                controller.Button("Down").AddKey(Key.Down);
                controller.Button("Left").AddKey(Key.Left);
                controller.Button("Right").AddKey(Key.Right);
                controller.Button("Start").AddKey(Key.Return);
            }
        }
    }
}
