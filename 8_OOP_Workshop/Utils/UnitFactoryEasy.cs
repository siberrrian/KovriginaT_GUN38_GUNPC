using _8_OOP_Workshop.Items.EconomicItems;
using _8_OOP_Workshop.Items.EquipItems;
using _8_OOP_Workshop.Units;

namespace _8_OOP_Workshop.Utils
{
    public sealed class UnitFactoryEasy : UnitFactory
    {
        public override Unit CreatePlayer(string name)
        {
            var player = new Player(name, 30, 30, 6);
            player.AddItemToInventory(new Weapon(10, 15, "Sword"));
            player.AddItemToInventory(new Armour(10, 15, "Armour"));
            player.AddItemToInventory(new Helmet(10, 15, "HelmetBasic"));
            player.AddItemToInventory(new HealthPotion("Potion"));
            player.AddItemToInventory(new Grindstone("Stone"));
            return player;
        }

        public override Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 18, 18, 2);

    }
    
}
