using System;
using System.Collections.Generic;

public class WeaponDatabase {
    public Dictionary<string, int> weaponPower;
    public Dictionary<string, int> weaponType;
    public WeaponDatabase()
    {

    }
    public void AddWeapon(string weaponName, int weaponMt, int weaponType) {
        weaponPower[weaponName] = weaponMt;
        weaponType[weaponName] = weaponType;
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
            Console.WriteLine("Hello World!");
        }
    }
}
