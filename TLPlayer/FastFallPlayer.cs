using Terraria.ModLoader;
using Terraria;
using TreasuredLiquor.Buffs.Alcohol;
using Terraria.DataStructures;

namespace TreasuredLiquor.TLPlayer
{
    public class FastFallPlayer : ModPlayer
    {
        private bool wasGlidingLastFrame = false;

        public override void PostUpdateRunSpeeds()
        {
            if (!Player.HasBuff(ModContent.BuffType<Buffs.Alcohol.FastFallBuff>()) || Player.mount.Active || Player.sliding)
                return;

            bool isGliding = Player.controlJump && Player.slowFall && Player.wingTime > 0 && Player.wingsLogic > 0;

            if (isGliding)
            {
                wasGlidingLastFrame = true;
                return;
            }

            if (wasGlidingLastFrame)
            {
                
                Player.velocity.Y += 6.0f; 
                wasGlidingLastFrame = false;
            }

            Player.maxFallSpeed = 150f;
        }
    }
}