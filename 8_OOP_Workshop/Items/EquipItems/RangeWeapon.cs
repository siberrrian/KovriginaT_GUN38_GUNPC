using _8_OOP_Workshop.Utils;

namespace _8_OOP_Workshop.Items.EquipItems
{
    public sealed class RangeWeapon : EquipItem
    {
        public RangeWeapon(uint damage, uint durability, string name) : base(durability, name) => Damage = damage;

        public uint Damage { get; }

        public override EquipSlot Slot => EquipSlot.RangeWeapon;
    }
}
