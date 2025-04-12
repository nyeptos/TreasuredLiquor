using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TreasuredLiquor.TLPlayer;

namespace TreasuredLiquor.Buffs.Alcohol
{
    public class CrazyMilkBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false;
            Main.pvpBuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<WallBreakerPlayer>().WallBreaker = true;

        }
    }
}