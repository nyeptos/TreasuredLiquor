using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TreasuredLiquor.TLPlayer
{

    public class WallBreakerPlayer : ModPlayer
    {
        public bool WallBreaker;
        public override void ResetEffects()
        {
            WallBreaker = false;
        }
        public override void PostItemCheck()
        {
            if (Player.HeldItem.hammer > 0 && WallBreaker && Player.itemAnimation > 0)
            {
                int tx = Player.tileTargetX;
                int ty = Player.tileTargetY;

                Point playerTile = Player.Center.ToTileCoordinates();

                int maxRangeX = Player.tileRangeX + Player.blockRange;
                int maxRangeY = Player.tileRangeY + Player.blockRange;

                if (Math.Abs(tx - playerTile.X) <= maxRangeX &&
                    Math.Abs(ty - playerTile.Y) <= maxRangeY)
                {
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            int wx = tx + x;
                            int wy = ty + y;

                            if (Framing.GetTileSafely(wx, wy).WallType > 0)
                            {
                                WorldGen.KillWall(wx, wy, false);
                                NetMessage.SendTileSquare(-1, wx, wy, 1);
                            }
                        }
                    }
                }
            }
        }
    }
}