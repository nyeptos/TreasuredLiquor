using Terraria;
using Terraria.ModLoader;
using Terraria.GameInput;
using TreasuredLiquor.Items.Accessories;
using TreasuredLiquor.UI;

namespace TreasuredLiquor.Common.Players
{
    public class AutoDrinkPlayer : ModPlayer
    {
        public override void PostUpdate()
        {
            foreach (Item item in Player.inventory)
            {
                if (item.ModItem is HipFlask flask && flask.storedPotions[0]?.stack > 0)
                {
                    var potion = flask.storedPotions[0];
                    if (potion.buffType > 0 && !Player.HasBuff(potion.buffType))
                    {
                        Player.AddBuff(potion.buffType, potion.buffTime); 
                        potion.stack--;
                    }
                }
            }
        }
    }
}