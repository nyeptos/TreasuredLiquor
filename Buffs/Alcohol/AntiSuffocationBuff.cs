using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace TreasuredLiquor.Buffs.Alcohol
{
    public class AntiSuffocationBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = false;
        }
    }
}