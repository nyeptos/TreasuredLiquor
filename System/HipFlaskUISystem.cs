using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using TreasuredLiquor.UI;

namespace TreasuredLiquor.Systems
{
    public class HipFlaskUISystem : ModSystem
    {
        public static UserInterface hipflaskInterface;
        public static UIHipFlask hipflaskUI;   

        public override void Load()
        {
            hipflaskUI = new UIHipFlask();
            hipflaskUI.Activate();
            hipflaskInterface = new UserInterface();
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (UIHipFlask.Visible)
            {
                hipflaskInterface?.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextLayerIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextLayerIndex != -1 && UIHipFlask.Visible)
            {
                layers.Insert(mouseTextLayerIndex, new LegacyGameInterfaceLayer(
                    "Hipflask UI", () =>
                    {
                        hipflaskInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI));
            }
        }

        public static void ToggleUI()
        {
            UIHipFlask.Visible = !UIHipFlask.Visible;
        }
    }
}