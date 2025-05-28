using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TreasuredLiquor.Buffs.Alcohol
{
    public class OldBottleDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true; 
            Main.buffNoSave[Type] = true; 
            Main.pvpBuff[Type] = true; 
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true; 
        }
    }
}