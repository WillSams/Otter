using Otter.Core;
using Otter.Graphics.Drawables;

namespace InputExample
{
    public sealed class PlayerEntity : AnimatingEntity
    {
        public PlayerEntity(Session session, int index)
            : base(session, $"gfx/sprites{index}.png", 40+(index*40), 30+(index*30)) { }

        public override void Update()
        {
            base.Update();
        }
    }
}
