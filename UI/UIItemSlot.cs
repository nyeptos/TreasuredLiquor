using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace TreasuredLiquor.UI
{
    public class UIItemSlot : UIElement
    {
        public Item item;  

        public UIItemSlot()
        {
            item = new Item();
            item.TurnToAir();
            Width.Set(52f, 0f);
            Height.Set(52f, 0f);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            CalculatedStyle dim = GetInnerDimensions();
            Texture2D texture = TextureAssets.InventoryBack.Value;
            spriteBatch.Draw(texture, dim.Position(), Color.White);
            ItemSlot.Draw(spriteBatch, ref item, ItemSlot.Context.InventoryItem, dim.Position());
        }

        public override void LeftClick(UIMouseEvent evt)
        {
            base.LeftClick(evt);
            ItemSlot.LeftClick(ref item, ItemSlot.Context.InventoryItem);
        }

        public override void RightClick(UIMouseEvent evt)
        {
            base.RightClick(evt);
            ItemSlot.RightClick(ref item, ItemSlot.Context.InventoryItem);
        }
    }
}