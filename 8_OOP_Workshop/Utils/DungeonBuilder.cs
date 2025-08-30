using _8_OOP_Workshop.Dungeon;
using _8_OOP_Workshop.Items.EconomicItems;
using _8_OOP_Workshop.Items.EquipItems;

namespace _8_OOP_Workshop.Utils
{
    public static class DungeonBuilder
    {
        public static DungeonRoom BuildDungeon(UnitFactory unitFactory)
        {
            var enter = new DungeonRoom("Enter");
            var monsterRoom = new DungeonRoom("Monster", unitFactory.CreateGoblinEnemy());
            var emptyRoom = new DungeonRoom("Empty");
            var lootRoom = new DungeonRoom("Loot1", new Gold());
            var lootStoneRoom = new DungeonRoom("Loot1", new Grindstone("Stone"));
            var lootWeaponRoom = new DungeonRoom("Loot4", new Weapon(10, 15, "Sword"));
            var lootRangeWeaponRoom = new DungeonRoom("Loot3", new RangeWeapon(15, 10,"RangeWeapon"));
            var lootHelmetRoom = new DungeonRoom("Loot2", new Helmet(10, 10, "HelmetLegendary"));
            var finalRoom = new DungeonRoom("Final", new Grindstone("Stone1"));

            enter.TrySetDirection(Direction.Right, monsterRoom);
            enter.TrySetDirection(Direction.Left, lootWeaponRoom);
            enter.TrySetDirection(Direction.Forward, lootRangeWeaponRoom);
            lootWeaponRoom.TrySetDirection(Direction.Forward, lootHelmetRoom);

            monsterRoom.TrySetDirection(Direction.Forward, lootRoom);

            lootHelmetRoom.TrySetDirection(Direction.Forward, lootStoneRoom);
            lootStoneRoom.TrySetDirection(Direction.Forward, lootRangeWeaponRoom);

            lootRangeWeaponRoom.TrySetDirection(Direction.Forward, finalRoom);
            lootRangeWeaponRoom.TrySetDirection(Direction.Right, monsterRoom);

            lootRoom.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }
    }
}
