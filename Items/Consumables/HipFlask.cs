using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;
using TreasuredLiquor.Systems;

namespace TreasuredLiquor.Items.Accessories
{
    public class HipFlask : ModItem
    {
        public Item[] StoredPotions = new Item[1];

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.accessory = true;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Green;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.consumable = false; // アクセサリなので消耗しない
        }

        public override void RightClick(Player player)
        {
            HipFlaskUISystem.ToggleUI();
        }

        public override void SaveData(TagCompound tag)
        {
            if (StoredPotions[0]! = null) tag["potion"] = ItemIO.Save(StoredPotions[0]);
        }

        public override void LoadData(TagCompound tag)
        {
            if (tag.ContainsKey("potion")) storedPotions[0] = ItemIO.Load(tag.GetCompound("potion"));
        }
    }
}
