using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TreasuredLiquor.Buffs.Alcohol;

namespace TreasuredLiquor.Items.Consumables
{

    public class HipFlask : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 28;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.useTime = 17;
            Item.useAnimation = 17;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.buyPrice(silver: 5);
            Item.buffType = ModContent.BuffType<AntiSuffocationBuff>();
            Item.buffTime = 60 * 60; // 60秒
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient(ItemID.SandBlock, 10)
                .AddIngredient(ItemID.Cactus)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}