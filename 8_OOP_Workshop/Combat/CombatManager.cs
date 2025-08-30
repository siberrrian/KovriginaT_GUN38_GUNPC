﻿using _8_OOP_Workshop.Items.EconomicItems;
using _8_OOP_Workshop.Items.EquipItems;
using _8_OOP_Workshop.Units;
using _8_OOP_Workshop.Utils;

namespace _8_OOP_Workshop.Combat
{
    public sealed class CombatManager
    {
        private readonly Random _random = new();
        
        public Unit StartCombat(Unit player, Unit enemy) => PlayCombatRoutine(player, enemy);

        private Unit PlayCombatRoutine(Unit player, Unit enemy)
        {
            if (player is Player player1)
            {
                if ((!player1.Equipment.ContainsKey(EquipSlot.Weapon)) && player1.Equipment.ContainsKey(EquipSlot.RangeWeapon))
                {
                    Console.WriteLine("You don't have a weapon, but you have a RangeWeapon? (for its use type Yes):");
                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        Console.WriteLine("RangeWeapon used!!!");
                        Console.WriteLine($"{enemy.Name} is dead!");
                        return player;
                    }
                }
            }
            Console.WriteLine(GetCombatString());
            while (player.Health > 0 && enemy.Health > 0) 
            {
                if (Enum.TryParse<RockPaperScissors>(Console.ReadLine(), out var rockPaperScissors)) 
                {
                    HandleCombatInput(player, enemy, rockPaperScissors);
                }
                else
                {
                    Console.WriteLine(GetCombatString());
                }
            }
            if (player.Health > 0 && enemy.Health == 0) 
            {
                return player;
            }
            else if (player.Health == 0 && enemy.Health > 0) 
            {
                return enemy;
            }

            return null;
        }

        private string GetCombatString() => $"Type {RockPaperScissors.Rock} = {(int)RockPaperScissors.Rock}" +
            $" or {RockPaperScissors.Paper} = {(int)RockPaperScissors.Paper}" +
            $" or {RockPaperScissors.Scissors} = {(int)RockPaperScissors.Scissors}";

        private void HandleCombatInput(Unit player, Unit enemy, RockPaperScissors rockPaperScissors)
        {
            var enemyInput = (RockPaperScissors) _random.Next(1, 3+1);
            Console.WriteLine($"Result player = {rockPaperScissors} and enemy = {enemyInput}");
            switch (rockPaperScissors) 
            {
                // player hit
                case RockPaperScissors.Rock when enemyInput == RockPaperScissors.Scissors:
                    ApplyDamage(player, enemy);
                    break;
                case RockPaperScissors.Scissors when enemyInput == RockPaperScissors.Paper:
                    ApplyDamage(player, enemy);
                    break;
                case RockPaperScissors.Paper when enemyInput == RockPaperScissors.Rock:
                    ApplyDamage(player, enemy);
                    break;
                // enemy hit
                case RockPaperScissors.Scissors when enemyInput == RockPaperScissors.Rock:
                    ApplyDamage(enemy, player);
                    break;
                case RockPaperScissors.Paper when enemyInput == RockPaperScissors.Scissors:
                    ApplyDamage(enemy, player);
                    break;
                case RockPaperScissors.Rock when enemyInput == RockPaperScissors.Paper:
                    ApplyDamage(enemy, player);
                    break;
                default:
                    Console.WriteLine("Combatants tried to hit, but missed :(");
                    break;
            }
        }

        private void ApplyDamage(Unit attacker, Unit defender)
        {
            defender.ApplyDamage(attacker.GetUnitDamage());
            Console.WriteLine($"{attacker.Name} hits {defender.Name}. {defender.Name} health {defender.Health}/{defender.MaxHealth}");
            if (attacker is Player player)
            {
                if (player.Equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon)
                {
                    player.ApplyReduceDurability(weapon, 1);
                    Console.WriteLine($"{weapon.Name} durability = {weapon.Durability}");
                }
            }
            if (defender.Health == 0) 
            {
                Console.WriteLine($"{defender.Name} is dead!");
            }
        }
    }
}
