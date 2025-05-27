namespace TreasuredLiquor.Systems.PotionLogic
{
    public interface IPotionUseCondition
    {
        bool ShouldUse(Player player, Item potion);
    }

    public class AlwaysUseCondition : IPotionUseCondition
    {
        public bool ShouldUse(Player player, Item potion) => true;
    }

    public class BuffMissingCondition : IPotionUseCondition
    {
        public bool ShouldUse(Player player, Item potion)
        {
            return potion.buffType > 0 && !player.HasBuff(potion.buffType);
        }
    }

    public class BuffExpiredCondition : IPotionUseCondition
    {
        public bool ShouldUse(Player player, Item potion)
        {
            return potion.buffType > 0 && !player.HasBuff(potion.buffType);
        }
    }

    public class DebuffDetectedCondition : IPotionUseCondition
    {
        private int[] targetDebuffs;

        public DebuffDetectedCondition(params int[] debuffIDs)
        {
            targetDebuffs = debuffIDs;
        }

        public bool ShouldUse(Player player, Item potion)
        {
            foreach (int debuff in targetDebuffs)
            {
                if (player.HasBuff(debuff))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class EnemyNearbyCondition : IPotionUseCondition
    {
        private float detectionRadius;

        public EnemyNearbyCondition(float radius = 600f)
        {
            detectionRadius = radius;
        }

        public bool ShouldUse(Player player, Item potion)
        {
            foreach (NPC npc in Main.npc)
            {
                if (npc.active && npc.CanBeChasedBy() && !npc.friendly &&
                    Vector2.Distance(player.Center, npc.Center) <= detectionRadius)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public static class PotionConditionRegistry
    {
        public static List<Type> RegisteredConditions = new List<Type>
        {
            typeof(AlwaysUseCondition),
            typeof(BuffMissingCondition),
            typeof(EnemyNearbyCondition),
            typeof(BuffExpiredCondition),
            typeof(DebuffDetectedCondition)
        };
    }
}