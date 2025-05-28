using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TreasuredLiquor.Buffs.Alcohol;

namespace TreasuredLiquor.TLPlayer
{

    public class SuffocationPlayer : ModPlayer
    {
        public override void PostUpdate()
        {
            if (Player.HasBuff(ModContent.BuffType<AntiSuffocationBuff>()))
            {
               
                Player.ClearBuff(BuffID.Suffocation);
            }
        }
    }
}