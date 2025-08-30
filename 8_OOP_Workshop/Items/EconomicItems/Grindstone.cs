namespace _8_OOP_Workshop.Items.EconomicItems
{
    public sealed class Grindstone : EconomicItem
    {
        public uint DurabRestore => 4;
        public override bool Stackable => false;

        public Grindstone(string name) : base(name)
        {
        }    
    }
}
