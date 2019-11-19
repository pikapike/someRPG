﻿using System;
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
            Character enemy = new Character("Player", new List<int>{12, 7, 7, 5, 5}, enemyWeapon);
            Console.WriteLine("Test line");
            // TESTING BATTLE
            List<Character> Team1 = new List<Character>(); Team1.Add(player);
            List<Character> Team2 = new List<Character>(); Team2.Add(enemy);
            Battle testbattle = new Battle("TestBattle", weaponDatabase, Team1, Team2);
            testbattle.TestTurn();

        }
    }
}
