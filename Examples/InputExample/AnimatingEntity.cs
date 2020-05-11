using Otter.Core;
using Otter.Graphics.Drawables;

namespace InputExample
{
    public class AnimatingEntity : Entity
    {
        protected readonly Session _session;
        readonly Spritemap<Animation> _spritemap;

        public AnimatingEntity(Session session, string spriteFile, float x, float y) : base(x, y)
        {
            _session = session;
            _spritemap = new Spritemap<Animation>(spriteFile, 32, 32);

            _spritemap.Add(Animation.WalkUp, "0,1,2,3,4,5", 4);
            _spritemap.Add(Animation.WalkRight, "6,7,8,9,10,11", 4);
            _spritemap.Add(Animation.WalkDown, "12,13,14,15,16,17", 4);
            _spritemap.Add(Animation.WalkLeft, "18,19,20,21,22,23", 4);
            _spritemap.Add(Animation.PlayOnce, "5,11,17,23,5,11,17,23", 6).NoRepeat();
            _spritemap.Add(Animation.PingPong, "2,8,14,20", 8).PingPong();

            _spritemap.CenterOrigin();

            // Play the walking down animation immediately.
            _spritemap.Play(Animation.WalkDown);

            AddGraphic(_spritemap);
        }

        public override void Update()
        {
            base.Update();

            var controller = _session.Controller;
            if (controller.Button("Up").Pressed) _spritemap.Play(Animation.WalkUp);
            if (controller.Button("Down").Pressed) _spritemap.Play(Animation.WalkDown);
            if (controller.Button("Left").Pressed) _spritemap.Play(Animation.WalkLeft);
            if (controller.Button("Right").Pressed) _spritemap.Play(Animation.WalkRight);
            if (controller.Button("Action1").Pressed) _spritemap.Play(Animation.PlayOnce);
            if (controller.Button("Action2").Pressed) _spritemap.Play(Animation.PingPong);
        }
    }
}
