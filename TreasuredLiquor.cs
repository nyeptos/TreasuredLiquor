using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria;
using Terraria.UI;
using Microsoft.Xna.Framework.Input;
using Terraria.GameInput;
using TreasuredLiquor.Systems;
using Terraria.ID;

namespace TreasuredLiquor
{
    public class TreasuredLiquor : Mod
    {
        public static ModKeybind OpenHipFlaskUIHotkey;

        public override void Load()
        {
            OpenHipFlaskUIHotkey = KeybindLoader.RegisterKeybind(this, "Open Hip Flask UI", "K");
        }

        public override void Unload()
        {
            OpenHipFlaskUIHotkey = null;
        }
    }
}
