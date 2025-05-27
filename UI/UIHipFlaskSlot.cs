using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.ID;
using Terraria.UI.Chat;
using TreasuredLiquor.Items.Accessories;
using TreasuredLiquor.Systems.PotionLogic;
using System;
using System.Collections.Generic;

namespace TreasuredLiquor.UI
{
    public class UIHipFlaskSlot : UIElement
    {
        private int index;
        private Item item;
        private UITextPanel<string> conditionButton;
        private UIElement dropdownPanel;
        private bool dropdownVisible = false;

        public UIHipFlaskSlot(int index)
        {
            this.index = index;
            this.Width.Set(40f, 0f);
            this.Height.Set(40f, 0f);
            this.item = new Item();
            this.item.TurnToAir();

            conditionButton = new UITextPanel<string>("[Select conditions]");
            conditionButton.Left.Set(44f, 0f);
            conditionButton.Top.Set(0f, 0f);
            conditionButton.OnClick += ToggleDropdown;
            Append(conditionButton);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            var dimensions = GetDimensions();
            spriteBatch.Draw(TextureAssets.InventoryBack.Value, dimensions.Position(), Color.White);

            if (!item.IsAir)
            {
                Texture2D texture = TextureAssets.Item[item.type].Value;
                Rectangle frame = Main.itemAnimations[item.type] != null
                    ? Main.itemAnimations[item.type].GetFrame(texture)
                    : texture.Frame();

                float scale = 1f;
                float availableWidth = 32f;
                if (frame.Width > availableWidth || frame.Height > availableWidth)
                {
                    scale = availableWidth / (float)Math.Max(frame.Width, frame.Height);
                }

                Vector2 position = dimensions.Position() + new Vector2(20f - frame.Width * scale / 2, 20f - frame.Height * scale / 2);
                spriteBatch.Draw(texture, position, frame, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            }
        }

        public override void Click(UIMouseEvent evt)
        {
            base.Click(evt);

            if (Main.mouseItem.IsAir && !item.IsAir)
            {
                Main.mouseItem = item.Clone();
                item.TurnToAir();
            }
            else if (!Main.mouseItem.IsAir)
            {
                Item temp = item.Clone();
                item = Main.mouseItem.Clone();
                Main.mouseItem = temp;
            }

            UpdateHipFlaskSlot();
        }

        private void UpdateHipFlaskSlot()
        {
            var player = Main.LocalPlayer;
            foreach (var invItem in player.armor)
            {
                if (invItem?.ModItem is HipFlask flask)
                {
                    flask.PotionSlots[index].Potion = item.Clone();
                }
            }
        }

        private void ToggleDropdown(UIMouseEvent evt, UIElement listeningElement)
        {
            dropdownVisible = !dropdownVisible;

            if (dropdownVisible)
                ShowDropdown();
            else
                RemoveChild(dropdownPanel);
        }

        private void ShowDropdown()
        {
            dropdownPanel = new UIElement();
            dropdownPanel.Left.Set(44f, 0f);
            dropdownPanel.Top.Set(20f, 0f);
            dropdownPanel.Width.Set(100f, 0f);
            dropdownPanel.Height.Set(PotionConditionRegistry.RegisteredConditions.Count * 24f, 0f);
            dropdownPanel.BackgroundColor = new Color(60, 60, 60, 200);

            for (int i = 0; i < PotionConditionRegistry.RegisteredConditions.Count; i++)
            {
                var condType = PotionConditionRegistry.RegisteredConditions[i];
                string displayName = PotionConditionRegistry.GetDisplayName(condType);

                var btn = new UITextPanel<string>(displayName);
                btn.Top.Set(i * 24f, 0f);
                btn.Width.Set(100f, 0f);
                btn.Height.Set(24f, 0f);

                btn.OnClick += (evt, element) =>
                {
                    dropdownVisible = false;
                    RemoveChild(dropdownPanel);

                    foreach (var invItem in Main.LocalPlayer.armor)
                    {
                        if (invItem?.ModItem is HipFlask flask)
                        {
                            flask.PotionSlots[index].Condition = (IPotionUseCondition)Activator.CreateInstance(condType);
                            conditionButton.SetText(displayName);
                            break;
                        }
                    }
                };

                dropdownPanel.Append(btn);
            }

            Append(dropdownPanel);
        }

        private void OnConditionSelected(int slotIndex, string selectedConditionName)
        {
            Type conditionType = PotionConditionRegistry.RegisteredConditions
                .FirstOrDefault(t => t.Name == selectedConditionName);

            if (conditionType != null && typeof(IPotionUseCondition).IsAssignableFrom(conditionType))
            {
                IPotionUseCondition instance = (IPotionUseCondition)Activator.CreateInstance(conditionType);

                var player = Main.LocalPlayer;
                foreach (var item in player.armor)
                {
                    if (item?.ModItem is HipFlask flask)
                    {
                        flask.PotionSlots[slotIndex].Condition = instance;
                    }
                }
            }
        }
    }
}
