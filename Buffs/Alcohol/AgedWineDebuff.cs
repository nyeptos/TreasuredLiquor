using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TreasuredLiquor.Buffs.Alcohol
{
    public class AgedWineDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true; // デバフとして設定
            Main.buffNoSave[Type] = true; // セーブしない
            Main.pvpBuff[Type] = true; // PvP時に有効
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true; // 看護師が解除できない
        }
    }
}