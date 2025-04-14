using Terraria;
using Terraria.ModLoader;
using TreasuredLiquor.TLPlayer;

namespace TreasuredLiquor.Globals
{
    public class WallBreakerGlobalItem : GlobalItem
    {
        private int originalHammerPower = -1;
        public override bool InstancePerEntity => true;
        public override void SetDefaults(Item item)
        {
            if (item.hammer > 0)
            {
                originalHammerPower = item.hammer;
            }
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (item.hammer > 0 && player.GetModPlayer<WallBreakerPlayer>().WallBreaker)
            {
                item.hammer = originalHammerPower + 10; 
            }
            else
            {
                item.hammer = originalHammerPower; 
            }
        }
        public override float UseSpeedMultiplier(Item item, Player player)
        {
            if (item.hammer > 0 && player.GetModPlayer<WallBreakerPlayer>().WallBreaker)
            {
                return 2.0f;
            }
            return 1f;
        }
        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            if (item.hammer > 0 && player.GetModPlayer<WallBreakerPlayer>().WallBreaker)
            {
                damage *= 0.1f; 
            }
        }
        public override void ModifyWeaponCrit(Item item, Player player, ref float crit)
        {
            if (item.hammer > 0 && player.GetModPlayer<WallBreakerPlayer>().WallBreaker)
            {
                crit = 0;
            }
        }
    }
}
