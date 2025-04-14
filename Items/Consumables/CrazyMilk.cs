using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TreasuredLiquor.Items.Consumables;

public class CrazyMilk : ModItem
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
        Item.buffType = ModContent.BuffType<Buffs.Alcohol.CrazyMilkBuff>();
        Item.buffTime = 10800;
    }
    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.MilkCarton, 1);
        recipe.AddIngredient(ItemID.Bottle, 1);
        recipe.AddIngredient(ItemID.Blinkroot, 2);
        recipe.AddTile(TileID.Kegs);
        recipe.Register();
    }
}
