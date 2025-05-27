using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace TreasuredLiquor.Systems.UI
{
    public class HipFlaskUIManager : ModSystem
    {
        internal static UserInterface HipFlaskInterface;
        internal static UI.UIHipFlask HipFlaskUI;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                HipFlaskUI = new UI.UIHipFlask();
                HipFlaskInterface = new UserInterface();
                HipFlaskInterface.SetState(HipFlaskUI);
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (HipFlaskInterface?.CurrentState != null)
            {
                HipFlaskInterface.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int inventoryLayerIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (inventoryLayerIndex != -1)
            {
                layers.Insert(inventoryLayerIndex + 1, new LegacyGameInterfaceLayer(
                    "TreasuredLiquor: HipFlask UI",
                    delegate
                    {
                        if (HipFlaskInterface?.CurrentState != null)
                        {
                            HipFlaskInterface.Draw(Main.spriteBatch, new GameTime());
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }

        public static void ToggleUI()
        {
            if (HipFlaskInterface.CurrentState == null)
            {
                HipFlaskInterface.SetState(HipFlaskUI);
            }
            else
            {
                HipFlaskInterface.SetState(null);
            }
        }
    }
}