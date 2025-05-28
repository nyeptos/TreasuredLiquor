using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TreasuredLiquor.Buffs.Alcohol;

namespace TreasuredLiquor.Items.Consumables
{
    public class FallingStar : ModItem
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
            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.buyPrice(silver: 5);
            Item.buffType = ModContent.BuffType<FastFallBuff>();
            Item.buffTime = 1800; // 30秒
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient(ItemID.Feather, 3)
                .AddIngredient(ItemID.FallenStar)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}