using _8_OOP_Workshop.Utils;

namespace _8_OOP_Workshop.Items.EquipItems
{
    public sealed class Helmet : EquipItem
    {
        public Helmet(uint defence, uint durability, string name) : base(durability, name) => Defence = defence;

        public uint Defence { get; }

        public override EquipSlot Slot => EquipSlot.Helmet;
    }
}
