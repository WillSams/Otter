using Otter.Core;
using Otter.Graphics;

namespace AnimatingSpritemaps
{
  class Program
  {
    static void Main(string[] args)
    {
      // Create a game that's 160 x 120
      using(var game = new Game("Spritemap Animation", 160, 120))
      {
        // Set the window scale to 3x to see the sprite better.
        game.SetWindowScale(3);
        // Set the background color to a bluish hue.
        game.Color = new Color(0.3f, 0.5f, 0.7f);

        // Create a scene.
        var scene = new Scene();
        // Add the animating entity to the scene.
        scene.Add(new AnimatingEntity(game.HalfWidth, game.HalfHeight));

        // Start the game with the scene that was just created.
        game.Start(scene);
      }
    }
  }
}
