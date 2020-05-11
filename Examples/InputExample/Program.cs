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

            using(var game = new Game("Input Example", 160, 120))
            {
                game.SetWindowScale(3);

                game.Color = new Color("749ace");

                game.AddSession(players[0]);
                SetUpController(game.Session(players[0]).Controller);

                game.AddSession(players[1], new ControllerXbox360());
                SetUpController(game.Session(players[1]).Controller, 0);

                game.AddSession(players[2], new ControllerPS3());
                SetUpController(game.Session(players[2]).Controller, 1);

                game.Color = new Color(0.4f, 0.4f, 0.8f);

                var scene = new Scene();
                for (var index = 0; index < players.Length; index++)
                {
                    scene.Add(new AnimatingEntity(
                        session: game.Session(players[index]),
                        spriteFile: $"gfx/sprites{index}.png",
                        x: 40+(index*40),
                        y: 30+(index*30))
                    );
                }
                game.Start(scene);
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
                controller.Button("Action1").AddJoyButton(0, joyIndex.GetValueOrDefault());  // 'A' on XBox, 'Triangle' on PS
                controller.Button("Action2").AddJoyButton(1, joyIndex.GetValueOrDefault());  // 'B' on XBox, 'Circle' on PS
                controller.Button("Up")
                    .AddAxisButton(AxisButton.YMinus, joyIndex.GetValueOrDefault())
                    .AddAxisButton(AxisButton.PovYMinus, joyIndex.GetValueOrDefault());
                controller.Button("Down")
                    .AddAxisButton(AxisButton.YPlus, joyIndex.GetValueOrDefault())
                    .AddAxisButton(AxisButton.PovYPlus, joyIndex.GetValueOrDefault());
                controller.Button("Left")
                    .AddAxisButton(AxisButton.XMinus, joyIndex.GetValueOrDefault())
                    .AddAxisButton(AxisButton.PovXMinus, joyIndex.GetValueOrDefault());
                controller.Button("Right")
                    .AddAxisButton(AxisButton.XPlus, joyIndex.GetValueOrDefault())
                    .AddAxisButton(AxisButton.PovXPlus, joyIndex.GetValueOrDefault());
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
