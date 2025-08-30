using _8_OOP_Workshop.Items.EconomicItems;
using _8_OOP_Workshop.Items.EquipItems;
using _8_OOP_Workshop.Units;

namespace _8_OOP_Workshop.Utils
{
    public abstract class UnitFactory
    {
        public abstract Unit CreatePlayer(string name);
        
        public abstract Unit CreateGoblinEnemy();
    }
}
