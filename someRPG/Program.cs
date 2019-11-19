using System;
using System.Collections.Generic;

namespace someRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            WeaponDatabase weaponDatabase = new WeaponDatabase();
            weaponDatabase.AddWeapon("Wooden Sword", 5, 0);
            Weapon playerWeapon = new Weapon("Wooden Sword", new List<int>());
            Character player = new Character("Player", new List<int>{20, 10, 10, 5, 5}, playerWeapon);
            Weapon enemyWeapon = new Weapon("Wooden Sword", new List<int>());
            Character enemy = new Character("Enemy", new List<int>{12, 7, 7, 5, 5}, enemyWeapon);
            // TESTING BATTLE
            List<Character> Team1 = new List<Character>(); Team1.Add(player);
            List<Character> Team2 = new List<Character>(); Team2.Add(enemy);
            Battle testbattle = new Battle("TestBattle", weaponDatabase, Team1, Team2);
            Console.WriteLine("Before Battle Phase");
            Console.WriteLine("Player Health: "+testbattle.GetTeam1()[0].GetHP().ToString());
            Console.WriteLine("Enemy Health: "+testbattle.GetTeam2()[0].GetHP().ToString());
            testbattle.SetupPhase();
            testbattle.RunPhase();
            Console.WriteLine("After Battle Phase");
            Console.WriteLine("Player Health: "+testbattle.GetTeam1()[0].GetHP().ToString());
            Console.WriteLine("Enemy Health: "+testbattle.GetTeam2()[0].GetHP().ToString());
        }
    }
}
