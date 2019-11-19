using System;
using System.Collections.Generic;

namespace someRPG {
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
        for (int i = 0; i < statsI.Count; i++) {
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
}