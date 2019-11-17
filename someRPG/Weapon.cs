using System;
using System.Collections.Generic;

namespace someRPG
{
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
}