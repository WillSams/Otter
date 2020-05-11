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
            var controllers = new object[] { null, new ControllerPS3(), new ControllerXbox360() };

            using(var game = new Game("Input Example", 160, 120))
            {
                game.SetWindowScale(3);

                game.Color = new Color("749ace");
                game.Color = new Color(0.4f, 0.4f, 0.8f);

                var scene = new Scene();
                for (var index = 0; index < players.Length; index++)
                {
                    game.AddSession(players[index], controllers[index] as Controller);
                    scene.Add(new AnimatingEntity(
                        session: game.Session(players[index]),
                        spriteFile: $"gfx/sprites{index}.png",
                        x: 40+(index*40),
                        y: 30+(index*30))
                    );
                }

                GameInput.SetUp(game.Session(players[0]).Controller);
                GameInput.SetUp(game.Session(players[1]).Controller, joyIndex: 0);
                GameInput.SetUp(game.Session(players[2]).Controller, joyIndex: 1);

                game.Start(scene);
            }
        }
    }
}
