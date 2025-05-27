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
        internal static UserInterface HipFlaskInterface;
        internal static UIHipFlask HipFlaskUI;
        private static bool Visible;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                HipFlaskInterface = new UserInterface();
                HipFlaskUI = new UIHipFlask();
                HipFlaskUI.Activate();
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (Visible && HipFlaskInterface?.CurrentState != null)
            {
                HipFlaskInterface.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int inventoryLayerIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));

            if (inventoryLayerIndex != -1 && Visible)
            {
                layers.Insert(inventoryLayerIndex, new LegacyGameInterfaceLayer(
                    "TreasuredLiquor: HipFlaskUI",
                    delegate
                    {
                        HipFlaskInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }

        public static void ToggleUI()
        {
            Visible = !Visible;
            if (Visible)
            {
                HipFlaskInterface?.SetState(HipFlaskUI);
            }
            else
            {
                HipFlaskInterface?.SetState(null);
            }
        }
    }
}