using _8_OOP_Workshop.Items.EconomicItems;
using _8_OOP_Workshop.Items.EquipItems;
using _8_OOP_Workshop.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace _8_OOP_Workshop.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Dictionary<EquipSlot, EquipItem> Equipment => _equipment;

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {            
        }

        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon) 
            {
                return BaseDamage + weapon.Damage;
            }
            return BaseDamage;
        }

        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            var itemsCount = items.Count;
            for (int i = itemsCount - 1; i >= 0 ; i--) 
            {
                if (items[i] is EconomicItem economicItem) 
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
            }
        }

        public override void AddItemToInventory(Item item)
        {
            if (item is EquipItem equipItem) 
            {
                ApplyEquip(equipItem);
                return;
            }

            base.AddItemToInventory(item);
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion) 
            {
                Health = Health + healthPotion.HealthRestore <= MaxHealth ? Health + healthPotion.HealthRestore : MaxHealth;
            }
            if (economicItem is Grindstone grindstone)
            {
                if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon)
                {
                    weapon.Repair(grindstone.DurabRestore);
                }
            }
        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour) 
            {
                damage -= (uint)(damage * (armour.Defence / 100f));
            }
            return damage;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Health {Health}/{MaxHealth}");
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon)
            {
                builder.AppendLine($"Durability {item.Name}: {item.Durability}");
            }
            builder.AppendLine("Loot:");
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++) 
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }

        public void ApplyReduceDurability(EquipItem equipItem, uint delta)
        {
            equipItem.ReduceDurability(delta);
        }

        public void ApplyEquip(EquipItem equipItem)
        {
            if (_equipment.TryAdd(equipItem.Slot, equipItem))
            {
                Console.WriteLine($"[{equipItem.Name}] was equipped.");
            } else if (_equipment.ContainsKey(equipItem.Slot))
            {
                Console.WriteLine("Replace equipment? (to replace type Yes):");
                if (Console.ReadLine().ToLower() == "yes")
                {
                    _equipment[equipItem.Slot] = equipItem;
                    Console.WriteLine($"EquipSlot.{equipItem.Slot} => {equipItem.Name}");
                }
            }
        }

    }
}
