using System;
using System.Collections.Generic;

public class WeaponDatabase {
    public Dictionary<string, int> weaponPower; // Weapon Mt
    public Dictionary<string, int> weaponType; // To distinguish between different weapon type which have different effects
    public WeaponDatabase()
    {
        this.weaponPower = new Dictionary<string, int>();
        this.weaponType = new Dictionary<string, int>();
    }
    public void AddWeapon(string name, int mt, int type) {
        weaponPower[name] = mt;
        weaponType[name] = type;
    }
    public int GetPower(string weapon) {
        return weaponPower[weapon];
    }
    public int GetType(string weapon) {
        return weaponType[weapon];
    }
}

public class Weapon {
    public string weapon;
    public List<int> enhancements;
    public Weapon(string weapon, List<int> enhancements)
    {
        this.weapon = weapon;
        this.enhancements = enhancements;
    }
    public int GetPower(WeaponDatabase database) // I have a feeling this database should be made global or something; don't want to feed it into a function
    {
        return database.GetPower(weapon);
    }
    public int GetType(WeaponDatabase database)
    {
        return database.GetType(weapon);
    }
    public List<int> GetEnhancements() {
        return enhancements;
    }
}
public class Character {
    public string name;
    public Weapon weapon;
    public List<int> statsI; // Initial stats: HP, Atk, Spd, Def, Res (probably)
    public List<int> statsD; // Represents difference of current stats from initial stats due to lost HP or debuffs
    public Character(string name, List<int> stats, Weapon weapon)
    {
        this.name = name;
        this.statsI = stats;
        this.statsD = new List<int>(new int[this.statsI.Count]);
        this.weapon = weapon;
    }
    public string GetName()
    {
        return name;
    }
    public Weapon GetWeapon()
    {
        return weapon;
    }
    public List<int> GetCurrentStats()
    {
        List<int> statsComb = new List<int>();
        for (int i = 0; i < statsComb.Count; i++) {
            statsComb.Add(statsI[i]+statsD[i]);
        }
        return statsComb;
    }
    public int GetHP() {
        return GetCurrentStats()[0];
    }
    public int GetAttack(WeaponDatabase database)
    {
        return GetCurrentStats()[1]+GetWeapon().GetPower(database);
    }
    public int GetSpeed() {
        return GetCurrentStats()[2];
    }
    public int GetDefense() {
        return GetCurrentStats()[3];
    }
    public int GetResistance() {
        return GetCurrentStats()[4];
    }
    public void TakeDamageFromEnemy(Character aggressor, WeaponDatabase database) {
        int damage = Math.Max(aggressor.GetAttack(database) - GetDefense(), 0);
        statsD[0] = Math.Max(statsD[0]-damage, statsD[0]-statsI[0]);
    }
    public void TakeDamage(int damage) {
        statsD[0] = Math.Max(statsD[0]-damage, statsD[0]-statsI[0]);
    }
    public void HealDamage(int heal)
    {
        statsD[0] = Math.Min(statsD[0]+heal, 0);
    }
}

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
            Character enemy = new Character("Player", new List<int>{12, 7, 7, 5, 5}, playerWeapon);
        }
    }
}
