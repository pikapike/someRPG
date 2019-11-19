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
    public List<Character> GetAllCharacters() 
    {
        List<Character> allCharacters = new List<Character>();
        foreach (Character c in GetTeam1()) {
            allCharacters.Add(c);
        } foreach (Character c in GetTeam2()) {
            allCharacters.Add(c);
        }
        return allCharacters;
    }
    public List<Character> GetTurnQueue()
    {
        return turnQueue;
    }
    public void SetTurnQueue(List<Character> newTurnQueue)
    {
        turnQueue = newTurnQueue;
    }
    public WeaponDatabase GetWeaponDatabase()
    {
        return database;
    }
    public void AttackCharacter(Character aggressor, Character victim)
    {
        victim.TakeDamageFromEnemy(aggressor, GetWeaponDatabase());
    }
    public void SetupPhase()
    {
        // Creates queue by getting all Characters and then sorting them by speed
        List<Character> newTurnQueue = GetAllCharacters();
        newTurnQueue.Sort((c1,c2) => c1.GetSpeed().CompareTo(c2.GetSpeed()));
        SetTurnQueue(newTurnQueue);

    }
    public void RunPhase()
    {
        // Testing attack by attacking first player on other teams 
        foreach(Character c in GetTurnQueue()) {
            if (GetTeam1().Contains(c)) {
                AttackCharacter(c, GetTeam2()[0]);
            } else {
                AttackCharacter(c, GetTeam1()[0]);
            }
        }
    }

    }

}

