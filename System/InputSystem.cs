using Terraria.ModLoader;
using Terraria;
using Terraria.GameInput;
using TreasuredLiquor.Systems.UI;

namespace TreasuredLiquor.Common.Systems
{
    public class InputSystem : ModSystem
    {
        public override void PostUpdateInput()
        {
            if (TreasuredLiquor.ToggleHipFlaskUIKeybind.JustPressed)
            {
                HipFlaskUIManager.ToggleUI();
            }
        }
    }
}
