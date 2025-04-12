using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TreasuredLiquor.Buffs.Alcohol;

namespace TreasuredLiquor.Items.Consumables
{
    public class OldBottle : ModItem
    {
        private static readonly List<int> UnremovableDebuffs = new List<int>()
        {
            BuffID.PotionSickness,
            BuffID.Werewolf,
            BuffID.Merfolk,
            BuffID.ManaSickness,
            ModContent.BuffType<OldBottleDebuff>(),
            ModContent.BuffType<AgedWineDebuff>()

        };
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 20;
            ItemID.Sets.DrinkParticleColors[Type] = new Color[3]
            {
                new Color(255, 230, 230),
                new Color(250, 220, 220),
                new Color(245, 210, 210)
            };
        }
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 18;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 9999;
            Item.consumable = true;
            Item.rare = ItemRarityID.Red;
            Item.value = Item.buyPrice(0, 0, 50, 0);
            Item.buffType = ModContent.BuffType<OldBottleDebuff>();
        }
        public override bool? UseItem(Player player)
        {
            if (Main.myPlayer == player.whoAmI)
            {
                var removableDebuffs = player.buffType
                    .Where(buffId => buffId > 0 && buffId < Main.debuff.Length && Main.debuff[buffId] && !UnremovableDebuffs.Contains(buffId))
                    .ToList();

                if (removableDebuffs.Count > 0)
                {
                    var randomBuff = new Random();
                    int randomIndex = randomBuff.Next(removableDebuffs.Count);
                    int debuffToRemove = removableDebuffs[randomIndex];
                    player.DelBuff(player.FindBuffIndex(debuffToRemove));
                }
                player.AddBuff(ModContent.BuffType<OldBottleDebuff>(), 10800);
                return true;
            }
            return false;
        }
        public override bool CanUseItem(Player player)
        {
            return !player.HasBuff(ModContent.BuffType<OldBottleDebuff>()) && HasRemovableDebuff(player);
        }
        private bool HasRemovableDebuff(Player player)
        {
            return player.buffType
                .Where(buffId => buffId > 0 && buffId < Main.debuff.Length && Main.debuff[buffId] && !UnremovableDebuffs.Contains(buffId))
                .Any();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Mushroom, 2);
            recipe.AddIngredient(ItemID.Deathweed);
            recipe.AddIngredient(ItemID.Ale);
            recipe.AddTile(TileID.Kegs);
            recipe.Register();
        }
    }
}