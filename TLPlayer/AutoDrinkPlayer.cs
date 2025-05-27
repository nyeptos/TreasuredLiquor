using Terraria;
using Terraria.ModLoader;
using TreasuredLiquor.Items.Accessories;

namespace TreasuredLiquor.Common.Players
{
    public class AutoDrinkPlayer : ModPlayer
    {
        private int potionCheckTimer = 0;

        public override void PostUpdate()
        {
            potionCheckTimer++;
            if (potionCheckTimer >= 60) // 毎秒実行（60tickごと）
            {
                TryAutoUsePotions();
                potionCheckTimer = 0;
            }
        }

        private void TryAutoUsePotions()
        {
            // アクセサリスロットから HipFlask を探す
            for (int i = 0; i < Player.armor.Length; i++)
            {
                Item item = Player.armor[i];
                if (item?.ModItem is HipFlask flask)
                {
                    foreach (var slot in flask.PotionSlots)
                    {
                        if (slot?.Potion == null || slot.Potion.IsAir)
                            continue;

                        if (slot.Condition?.ShouldUse(Player, slot.Potion) == true)
                        {
                            TryUsePotion(slot.Potion);
                        }
                    }
                }
            }
        }

        private void TryUsePotion(Item potion)
        {
            // ポーション使用条件チェック（クールダウンなど）
            if (Player.itemAnimation > 0 || Player.potionDelay > 0)
                return;

            if (potion?.consumable == true && potion.useStyle > 0)
            {
                Player.QuickBuff(); // バフポーションなど

                // 消費を手動処理（tModLoaderは自動処理しない）
                Player.ConsumeItem(potion.type);
            }
        }
    }
}