using _8_OOP_Workshop.Utils;

namespace _8_OOP_Workshop.Items.EconomicItems
{
    public sealed class Gold : EconomicItem
    {
        public override bool Stackable => true;

        public Gold() : base(GameConstants.Gold)
        {            
        }       
    }
}
