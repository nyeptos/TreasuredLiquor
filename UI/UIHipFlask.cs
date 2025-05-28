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
        private DraggableUIPanel panel;

        public override void OnInitialize()
        {
            panel = new DraggableUIPanel();
            panel.SetPadding(10);
            panel.Left.Set(400f, 0f);
            panel.Top.Set(100f, 0f);
            panel.Width.Set(300f, 0f);
            panel.Height.Set(200f, 0f);
            panel.BackgroundColor = new Color(73, 94, 171);

            Append(panel);

            for (int i = 0; i < HipFlask.MaxSlots; i++)
            {
                var slot = new UIHipFlaskSlot(i);
                slot.Top.Set(10 + i * 40, 0f); // スロット間隔
                slot.Left.Set(10, 0f);
                panel.Append(slot);
            }
        }
    }

    public class DraggableUIPanel : UIPanel
    {
        private Vector2 offset;
        private bool dragging;

        public override void LeftMouseDown(UIMouseEvent evt) // 修正: 正しいメソッド名に変更
        {
            base.LeftMouseDown(evt);
            offset = new Vector2(evt.MousePosition.X - Left.Pixels, evt.MousePosition.Y - Top.Pixels);
            dragging = true;
        }

        public override void LeftMouseUp(UIMouseEvent evt) // 修正: 正しいメソッド名に変更
        {
            base.LeftMouseUp(evt);
            dragging = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (dragging)
            {
                Left.Set(Main.mouseX - offset.X, 0f);
                Top.Set(Main.mouseY - offset.Y, 0f);
                Recalculate();
            }
        }
    }
}
