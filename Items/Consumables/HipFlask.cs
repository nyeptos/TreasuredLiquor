using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;
using static TreasuredLiquor.Systems.PotionLogic.EnemyNearbyCondition;
using TreasuredLiquor.Systems.PotionLogic;
using static TreasuredLiquor.Items.Accessories.HipFlask;

namespace TreasuredLiquor.Items.Accessories
{
    public class HipFlask : ModItem
    {
        public const int MaxSlots = 5;
        public List<PotionSlot> PotionSlots;

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(gold: 2);
        }
        public override void OnCreated(ItemCreationContext context)
        {
            base.OnCreated(context);
            PotionSlots = new List<PotionSlot>();
            for (int i = 0; i < MaxSlots; i++)
            {
                PotionSlots.Add(new PotionSlot());
            }
        }

        public override void SaveData(TagCompound tag)
        {
            tag["PotionSlots"] = PotionSlots.Select(slot => new TagCompound
            {
                ["Item"] = ItemIO.Save(slot.Potion),
                ["Condition"] = slot.Condition.GetType().FullName // 条件の型名を保存
            }).ToList();
        }

        public override void LoadData(TagCompound tag)
        {
            var list = tag.GetList<TagCompound>("PotionSlots");
            PotionSlots = new List<PotionSlot>();

            foreach (var entry in list)
            {
                var slot = new PotionSlot
                {
                    Potion = ItemIO.Load(entry.GetCompound("Item"))
                };

                string condTypeName = entry.GetString("Condition");
                Type condType = Mod.Code?.GetType(condTypeName);
                if (condType != null && typeof(IPotionUseCondition).IsAssignableFrom(condType))
                {
                    slot.Condition = (IPotionUseCondition)Activator.CreateInstance(condType);
                }
                else
                {
                    slot.Condition = new AlwaysUseCondition(); // fallback
                }

                PotionSlots.Add(slot);
            }

            while (PotionSlots.Count < MaxSlots)
            {
                PotionSlots.Add(new PotionSlot());
            }
        }
    }

    public class PotionSlot
    {
        public Item Potion;
        public IPotionUseCondition Condition;

        public PotionSlot()
        {
             Potion = new Item();
             Potion.TurnToAir();
             Condition = new AlwaysUseCondition(); // デフォルト：常に使う
        }
    }
}
