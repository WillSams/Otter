using Otter.Core;
using Otter.Components.Controllers;

namespace InputExample
{
    public sealed class GameInput
    {
        public static void SetUp(Controller controller, int? joyIndex=0)
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
