using Otter.Core;
using Otter.Graphics.Drawables;

namespace AnimatingSpritemaps
{
  class AnimatingEntity : Entity
  {
    // Create the Spritemap to use. Use Sprite.png as the texture, and define the cell size as 32 x 32.
    Spritemap<Animation> spritemap = new Spritemap<Animation>("sprite.png", 32, 32);

    public AnimatingEntity(float x, float y) : base(x, y)
    {
      // Add the animation data for walking upward.
      spritemap.Add(Animation.WalkUp, "0,1,2,3,4,5", 4);
      // Add the animation data for walking to the right.
      spritemap.Add(Animation.WalkRight, "6,7,8,9,10,11", 4);
      // Add the animation data for walking downward.
      spritemap.Add(Animation.WalkDown, "12,13,14,15,16,17", 4);
      // Add the animation data for walking to the left.
      spritemap.Add(Animation.WalkLeft, "18,19,20,21,22,23", 4);
      // Add the animation data for the PlayOnce test.
      spritemap.Add(Animation.PlayOnce, "5,11,17,23,5,11,17,23", 6).NoRepeat();
      // Add the animation data for the PingPong test.
      spritemap.Add(Animation.PingPong, "2,8,14,20", 8).PingPong();

      // Center the spritemap's origin.
      spritemap.CenterOrigin();
      // Play the walking down animation immediately.
      spritemap.Play(Animation.WalkDown);

      // Add the graphic to the Entity so that it renders.
      AddGraphic(spritemap);
    }

    public override void Update()
    {
      base.Update();

      if (Input.KeyPressed(Key.Up))
      {
        // Play the walk up animation when the up key is pressed.
        spritemap.Play(Animation.WalkUp);
      }
      if (Input.KeyPressed(Key.Down))
      {
        // Play the walk down animation when the down key is pressed.
        spritemap.Play(Animation.WalkDown);
      }
      if (Input.KeyPressed(Key.Left))
      {
        // Play the walk left animation when the left key is pressed.
        spritemap.Play(Animation.WalkLeft);
      }
      if (Input.KeyPressed(Key.Right))
      {
        // Play the walk right animation when the right key is pressed.
        spritemap.Play(Animation.WalkRight);
      }
      if (Input.KeyPressed(Key.X))
      {
        // Play the PlayOnce test animation.
        spritemap.Play(Animation.PlayOnce);
      }
      if (Input.KeyPressed(Key.C))
      {
        // Play the PingPong test animation.
        spritemap.Play(Animation.PingPong);
      }
    }

    // Set up an enum to use for the four different animations.
    enum Animation
    {
      WalkUp,
      WalkDown,
      WalkLeft,
      WalkRight,
      PlayOnce,
      PingPong
    }
  }
}
