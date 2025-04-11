using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TreasuredLiquor.Buffs.Alcohol;

namespace TreasuredLiquor.Items.Consumables
{
    public class AgedWine : ModItem
    {
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
            Item.buffType = ModContent.BuffType<AgedWineDebuff>();
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                bool extended = false;
                for (int i = 0; i < Player.MaxBuffs; i++)
                {
                    if (IsExtendable(player, i))
                    {
                        player.buffTime[i] += 10800;
                        extended = true;
                    }
                }
                if (extended)
                {
                    player.AddBuff(ModContent.BuffType<AgedWineDebuff>(), 10800);
                    return true;
                }
            }
            return false;
        }


        public override bool CanUseItem(Player player)
        {
            if (player.HasBuff(ModContent.BuffType<AgedWineDebuff>()))
                return false;
            for (int i = 0; i < Player.MaxBuffs; i++)
            {
                if (IsExtendable(player, i))
                {
                    return true;
                }

            }
            return false;
        }
        bool IsExtendable(Player player, int index)
        {
            int buffType = player.buffType[index];
            if (buffType <= 0) return false;
            if (Main.debuff[buffType]) return false;
            if (buffType == ModContent.BuffType<AgedWineDebuff>()) return false;
            if (Main.buffNoTimeDisplay[buffType]) return false;

            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BottledWater);
            recipe.AddIngredient(ItemID.Grapes, 5); 
            recipe.AddTile(TileID.Kegs); 
            recipe.Register();
        }
    }
}
