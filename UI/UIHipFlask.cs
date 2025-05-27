using Terraria;
using Terraria.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using ReLogic.Graphics;
using Terraria.GameContent;
using TreasuredLiquor.Items.Accessories;
using Terraria.GameContent.UI.Elements;

namespace TreasuredLiquor.UI
{
    public class UIHipFlask : UIState
    {
        private UIPanel mainPanel;
        private List<UIHipFlaskSlot> slotElements;

        public override void OnInitialize()
        {
            mainPanel = new UIPanel();
            mainPanel.SetPadding(10);
            mainPanel.Width.Set(300f, 0f);
            mainPanel.Height.Set(150f, 0f);
            mainPanel.Left.Set(400f, 0f); // X座標
            mainPanel.Top.Set(200f, 0f);  // Y座標
            Append(mainPanel);

            slotElements = new List<UIHipFlaskSlot>();

            for (int i = 0; i < HipFlask.MaxSlots; i++)
            {
                var slot = new UIHipFlaskSlot(i);
                slot.Left.Set(i * 50f, 0f); // スロットを横に並べる
                slot.Top.Set(10f, 0f);
                mainPanel.Append(slot);
                slotElements.Add(slot);
            }
        }
    }
}
