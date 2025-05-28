using Terraria.ModLoader;
using Terraria;

namespace TreasuredLiquor.Buffs.Alcohol
{

    public class FastFallBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
        }
    }
}