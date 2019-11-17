using System;
using System.Collections.Generic;

namespace someRPG
{
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
}