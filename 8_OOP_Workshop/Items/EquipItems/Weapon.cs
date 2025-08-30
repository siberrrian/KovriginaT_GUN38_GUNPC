﻿using _8_OOP_Workshop.Utils;

namespace _8_OOP_Workshop.Items.EquipItems
{
    public sealed class Weapon : EquipItem
    {
        public Weapon(uint damage, uint durability, string name) : base(durability, name) => Damage = damage;

        public uint Damage { get; }

        public override EquipSlot Slot => EquipSlot.Weapon;
    }
}
