using Terraria.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.ModLoader;
using TreasuredLiquor.Items.Accessories;
using Terraria.GameContent.UI.Elements;
using Terraria;

namespace TreasuredLiquor.UI
{
    public class UIHipFlask : UIState
    {
        public static bool Visible;
        private UIItemSlot potionSlot;
        private HipFlask targetFlask;

        public override void OnInitialize()
        {
            potionSlot = new UIItemSlot();
            potionSlot.Left.Set(400f, 0f);
            potionSlot.Top.Set(300f, 0f);
            Append(potionSlot);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public Item getItem() => potionSlot.item;

        public void SetTarget(HipFlask flask)
        {
            potionSlot.item = flask.storedPotions[0];
        }
    }
}
