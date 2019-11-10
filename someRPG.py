import random

class WeaponDatabase:
    def __init__(self):
        self.weaponMap = {}
    def addWeapon(self, weaponName, weaponMt, enhancements = []):
        self.weaponMap[weaponName] = [weaponMt, enhancements]
    def getWeaponData(self, weaponName):
        return self.weaponMap[weaponName]

class Character:
    def __init__(self, name, stats, weapon):
        self.name = name
        self.statsI = stats # Probably HP, Atk, Spd, Def, Res. Something like that, maybe more
        self.statsD = [0 for i in range(len(stats))] # Current stats' differential due to lost HP and (de)buffs
        self.weapon = weapon # Some type. Database needed.
    def getName(self):
        return self.name
    def getWeapon(self):
        return self.weapon
    def getCurrentStats(self):
        return [self.statsI[i] - self.statsD[i] for i in range(len(self.statsI))]
    def getAttack(self):
        return self.getCurrentStats()[1]+self.weapon[0]
    def getSpeed(self):
        return self.getCurrentStats()[2]
    def getDefense(self):
        return self.getCurrentStats()[3]
    def getResistance(self):
        return self.getCurrentStats()[4]
    def takeDamage(self, atkChar):
        damage = atkChar.getAttack() - self.getDefense()
        self.statsD[0] -= damage
        if self.getCurrentStats()[0] < 0:
            self.statsD[0] = self.statsI[0]
    def healDamage(self, heal):
        self.statsD[0] += damage
        if self.statsD[0] < 0:
            self.statsD[0] = 0

# Game loop:

weaponDatabase = WeaponDatabase()
weaponDatabase.addWeapon("Wooden Sword", 5)
player = Character("Player", [20, 10, 10, 5, 5], "Wooden Sword")
foes = [Character("Foe 1", [random.randint(2,8) for j in range(5)], "Wooden Sword") for i in range(3)]

print("Welcome to someRPG!")
print("-------------------")
print("A group of enemies have appeared!")
for foe in foes:
    print(foe.getName() + ":", foe.getCurrentStats(), foe.getWeapon())

while True:
    print("What will "+player.getName()+" do?")
    response = input()
    
    
