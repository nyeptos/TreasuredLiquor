using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TreasuredLiquor.Buffs.Alcohol
{
    public class AgedWineDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
    }
}