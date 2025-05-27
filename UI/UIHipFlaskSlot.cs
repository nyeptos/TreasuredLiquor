using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.UI;
using TreasuredLiquor.Items.Accessories;

namespace TreasuredLiquor.UI
{
    public class UIHipFlaskSlot : UIElement
    {
        private readonly int slotIndex;
        private float scale = 0.8f;

        public UIHipFlaskSlot(int index)
        {
            slotIndex = index;
            Width.Set(40f, 0f);
            Height.Set(40f, 0f);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);

            Player player = Main.LocalPlayer;
            if (player == null || player.dead) return;

            var hipFlask = GetEquippedHipFlask(player);
            if (hipFlask == null) return;

            if (slotIndex < 0 || slotIndex >= hipFlask.PotionSlots.Count) return;

            var item = hipFlask.PotionSlots[slotIndex].Potion;
            if (item == null || item.IsAir) return;

            // スロット背景
            CalculatedStyle dimensions = GetInnerDimensions();
            Texture2D backgroundTexture = Terraria.GameContent.TextureAssets.InventoryBack.Value;
            spriteBatch.Draw(backgroundTexture, dimensions.Position(), Color.White);

            // アイテム描画
            Texture2D itemTexture = Terraria.GameContent.TextureAssets.Item[item.type].Value;
            Rectangle sourceRectangle = Main.itemAnimations[item.type]?.GetFrame(itemTexture) ?? itemTexture.Bounds;
            Vector2 position = dimensions.Position() + new Vector2(20f) - sourceRectangle.Size() * scale / 2f;

            spriteBatch.Draw(itemTexture, position, sourceRectangle, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        private HipFlask GetEquippedHipFlask(Player player)
        {
            foreach (var item in player.armor)
            {
                if (item.ModItem is HipFlask flask)
                {
                    return flask;
                }
            }
            return null;
        }
    }
}
