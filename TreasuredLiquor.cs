using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.UI;
using Microsoft.Xna.Framework.Input;
using Terraria.GameInput;
using TreasuredLiquor.Systems.UI;

namespace TreasuredLiquor
{
    public class TreasuredLiquor : Mod
    {
        public static ModKeybind ToggleHipFlaskUIKeybind;

        public override void Load()
        {
            // ホットキー登録（例: Hキー）
            ToggleHipFlaskUIKeybind = KeybindLoader.RegisterKeybind(this, "Toggle HipFlask UI", "H");
        }

        public override void Unload()
        {
            ToggleHipFlaskUIKeybind = null;
        }
    }
}
