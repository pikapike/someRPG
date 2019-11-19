using System;
using System.Collections.Generic;

namespace someRPG {
    public class Battle {
    public string name;
    public List<Character> team1;
    public List<Character> team2;
    public List<Character> turnQueue;
    public WeaponDatabase database;
    public Battle(string name, WeaponDatabase database, List<Character> team1, List<Character> team2) {
        this.name = name;
        this.team1 = team1;
        this.team2 = team2;
        this.database = database;
    }
    public string GetName() 
    {
        return name;
    }
    public List<Character> GetTeam1()
    {
        return team1;
    }
    public List<Character> GetTeam2()
    {
        return team2;
    }
    public List<Character> GetTurnQueue()
    {
        return turnQueue;
    }
    public WeaponDatabase GetWeaponDatabase()
    {
        return database;
    }
    public void AttackCharacter(Character aggressor, Character victim)
    {
        victim.TakeDamageFromEnemy(aggressor, GetWeaponDatabase());
    }
    public void TestTurn()
    {
        // Has the first character in team1 attack the first character in team2
        // prints the attacked characters stats before and after the attack
        List<int> firststats = GetTeam2()[0].GetCurrentStats();
        AttackCharacter(GetTeam1()[0], GetTeam2()[0]);
        List<int> secondstats = GetTeam2()[0].GetCurrentStats();
        foreach (int stat in firststats)
        {
            Console.WriteLine(stat);
        }
        Console.WriteLine();
        foreach (int stat in secondstats)
        {
            Console.WriteLine(stat);
        }
    }

    }


}

