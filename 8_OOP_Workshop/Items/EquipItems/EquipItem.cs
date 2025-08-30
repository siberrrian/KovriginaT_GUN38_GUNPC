﻿using _8_OOP_Workshop.Items.EconomicItems;
using _8_OOP_Workshop.Utils;

namespace _8_OOP_Workshop.Items.EquipItems
{
    public abstract class EquipItem : Item
    {
        private uint _durability;
        private uint _maxDurability;
        public uint Durability { get => _durability; protected set => _durability = value; }
        public override bool Stackable => false;

        public abstract EquipSlot Slot { get; }

        protected EquipItem(uint maxDurability, string name) : base(name)
        {
            _maxDurability = maxDurability;
            _durability = _maxDurability;
        }

        public void ReduceDurability(uint delta) => _durability -= delta;

        public void Repair(uint delta) => 
            _durability = _durability + delta > _maxDurability 
            ? _maxDurability 
            : _durability + delta;
    }
}
