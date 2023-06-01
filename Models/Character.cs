using System.ComponentModel.DataAnnotations;
public class Character
{
    Random random = new Random();
    [Key]
    public int ID { get; set; }
    public string Name { get; set; } = "";
    public int Level { get; set; } = 1;
    public int CurrentXP { get; set; } = 0;
    public int LevelXP { get; set; } = 1000;
    public int HP { get; set; } = 6;
    public int Strength { get; set; } = 10;
    public int Dexterity { get; set; } = 10;
    public int Constitution { get; set; } = 10;
    public int Intelligence { get; set; } = 10;
    public int Wisdom { get; set; } = 10;
    public int Charisma { get; set; } = 10;
    public List<double> BaseAttackBonus { get; set; } = new List<double>();
    public Race? Race { get; set; }
    public Class? Class { get; set; }
    public int Gold { get; set; } = 0;
    public Weapon? Weapon { get; set; }
    public Armor? Armor { get; set; }
    public Armor? Helmet { get; set; }
    public Armor? Gloves { get; set; }
    public Armor? Boots { get; set; }
    public Shield? Shield { get; set; }
    public Jewelry? LeftRing { get; set; }
    public Jewelry? RightRing { get; set; }
    public Jewelry? Amulet { get; set; }
    public int ArmorClass { get; set; } = 10;
    public List<Object> Inventory = new List<Object>();
    public Character(string _Name)
    {
        Name = _Name;
    }
    public void AssignRace(Race _Race)
    {
        this.Race = _Race;
        this.Strength += _Race.StrengthModifier;
        this.Dexterity += _Race.DexterityModifier;
        this.Constitution += _Race.ConstitutionModifier;
        this.Intelligence += _Race.IntelligenceModifier;
        this.Wisdom += _Race.WisdomModifier;
        this.Charisma += _Race.CharismaModifier;
        if (_Race.ConstitutionModifier == 2) { this.HP += 1; }
    }

    public void AssignClass(Class _Class)
    {
        this.Class = _Class;
        this.HP += _Class.HPDieRoll;
        this.BaseAttackBonus.Add(this.Class.BaseAttackModifier);
    }
    public void UnequipShield()
    {
        this.ArmorClass -= this.Shield.ArmorClass;
        this.Inventory.Add(this.Shield);
        this.Shield = null;
    }
    public void UnequipArmor()
    {
        this.ArmorClass -= this.Armor.ArmorClass;
        this.Inventory.Add(this.Armor);
        this.Armor = null;
    }
    public void UnequipWeapon()
    {
        this.Inventory.Add(this.Weapon);
        this.Weapon = null;
    }
    public void EquipWeapon(Weapon _Weapon)
    {
        if (_Weapon.IsTwoHanded == true && this.Shield != null)
        {
            Console.WriteLine("You must remove your shield before equipping a two-handed weapon.");
        }
        else { this.Weapon = _Weapon; }
    }

    public void EquipArmor(Armor _Armor)
    {
        if (this.Armor != null)
        {
            this.ArmorClass -= this.Armor.ArmorClass;
        }
        this.Armor = _Armor;
        this.ArmorClass += _Armor.ArmorClass;
    }
    public void EquipShield(Shield _Shield)
    {
        if (this.Shield != null)
        {
            this.ArmorClass -= this.Shield.ArmorClass;
        }
        this.Shield = _Shield;
        this.ArmorClass += _Shield.ArmorClass;
    }
    public void LevelUp()
    {
        //Add 1 to the current player level
        this.Level += 1;
        //Increase player's HP. Random dice roll based on the class parameter with added bonus from
        //the player's constitution score.
        double RandomHPIncrease = random.Next(1, (this.Class.HPDieRoll + 1)) + (this.Constitution - 10) / 2;
        int HPIncrease = (int)Math.Floor(RandomHPIncrease);
        this.HP += HPIncrease;
        //Reset the current xp total. Keep xp that went over the required amount to level!
        this.CurrentXP = (this.CurrentXP - this.LevelXP);
        //Amount of xp needed to level up increases with every level.
        this.LevelXP += (this.Level * 1000);
        //Increase player's base attack bonus. Create a new list so there isn't a reference issue.
        List<double> NumberOfAttacks = new List<double>();
        foreach (double BaseAttackBonus in this.BaseAttackBonus)
        {
            NumberOfAttacks.Add(BaseAttackBonus + this.Class.BaseAttackModifier);
        }
        //Player gets an additional attack if their final attack in sequence has an attack bonus greater than 5.
        if (NumberOfAttacks[NumberOfAttacks.Count() - 1] >= 5)
        {
            NumberOfAttacks.Add(this.Class.BaseAttackModifier);
        }
        this.BaseAttackBonus = new List<double>();
        foreach (double attack in NumberOfAttacks)
        {
            this.BaseAttackBonus.Add(attack);
        }
        //Players get an attribute point every 4 levels.
        if (this.Level % 4 == 0)
        {
            bool UnassignedSkillPoint = true;
            while (UnassignedSkillPoint)
            {
                Console.Clear();
                Console.WriteLine("You gained an attribute point. Where do you want to assign it?");
                Console.WriteLine("");
                Console.WriteLine($"1: Strength (your current strength is {this.Strength})");
                Console.WriteLine($"1: Dexterity (your current Dexterity is {this.Dexterity})");
                Console.WriteLine($"1: Constitution (your current Constitution is {this.Constitution})");
                Console.WriteLine($"1: Intelligence (your current Intelligence is {this.Intelligence})");
                Console.WriteLine($"1: Wisdom (your current Wisdom is {this.Wisdom})");
                Console.WriteLine($"1: Charisma (your current Charisma is {this.Charisma})");
                string Input = Console.ReadLine();
                if (Input == "1")
                {
                    this.Strength += 1;
                    Console.Clear();
                    UnassignedSkillPoint = false;
                }
                else if (Input == "2")
                {
                    this.Dexterity += 1;
                    Console.Clear();
                    UnassignedSkillPoint = false;
                }
                else if (Input == "3")
                {
                    this.Constitution += 1;
                    Console.Clear();
                    UnassignedSkillPoint = false;
                    if (this.Constitution % 2 == 0) { this.HP += this.Level; }
                }
                else if (Input == "4")
                {
                    this.Intelligence += 1;
                    Console.Clear();
                    UnassignedSkillPoint = false;
                }
                else if (Input == "5")
                {
                    this.Wisdom += 1;
                    Console.Clear();
                    UnassignedSkillPoint = false;
                }
                else if (Input == "6")
                {
                    this.Charisma += 1;
                    Console.Clear();
                    UnassignedSkillPoint = false;
                }
                else { Console.Clear(); }
            }
        }
    }

    public void ShowStats()
    {
        Console.WriteLine($"Player name: {this.Name}");
        Console.WriteLine($"Level: {this.Level}");
        Console.WriteLine($"XP: {this.CurrentXP} of {this.LevelXP}");
        Console.WriteLine($"Current HP: {this.HP}");
        Console.WriteLine($"Strength: {this.Strength}");
        Console.WriteLine($"Dexterity: {this.Dexterity}");
        Console.WriteLine($"Constitution: {this.Constitution}");
        Console.WriteLine($"Intelligence: {this.Intelligence}");
        Console.WriteLine($"Wisdom: {this.Wisdom}");
        Console.WriteLine($"Charisma: {this.Charisma}");
        Console.WriteLine("-------");
        if (this.Weapon == null)
        {
            Console.WriteLine($"You are weilding a your bare knuckles");
        } else {
            Console.WriteLine($"You are weilding a {this.Weapon.Name}");
        }
        if (this.Shield != null)
        {
            Console.WriteLine($"Your left side is guarded by your {this.Shield.Name}");
        }
        if (this.Armor != null)
        {
            Console.WriteLine($"Your torso is protexted by your {this.Armor.Name}");
        }
        Console.WriteLine($"Your armor class is {this.ArmorClass} and your attacks are:");
        foreach (double BaseAttackBonus in this.BaseAttackBonus)
        {
            Console.WriteLine(BaseAttackBonus);
        }
        int XPBonus = (this.Wisdom - 10);
        Console.WriteLine($"You have an xp bonus of {XPBonus}%");
        int ShopBonus = (this.Charisma - 10);
        Console.WriteLine($"You have an shop cost to buy/sell of {ShopBonus}%");
        Console.WriteLine("");
        Console.WriteLine("--press enter to continue--");
        Console.ReadLine();
    }
    public int d(int Max)
    {
        return random.Next(1, (Max + 1));
    }
    public void Attack(Character Enemy)
    {
        List<int> Attacks = new List<int>();
        List<bool> Crits = new List<bool>();
        int AttackRoll = 0;
        //Check if the player is a Monk and give them an additional attack if they are.
        if (this.Class.DoubleAttack)
        {
            AttackRoll = d(20);
            if (AttackRoll >= this.Weapon.CriticalRate) { Crits.Add(true); } else { Crits.Add(false); }
            AttackRoll += (int)Math.Floor(this.BaseAttackBonus[0]) + (int)((this.Dexterity - 10) / 2);
            Attacks.Add(AttackRoll);
        }
        foreach (double BaseAttackBonus in this.BaseAttackBonus)
        {
            AttackRoll = d(20);
            if (AttackRoll >= this.Weapon.CriticalRate) { Crits.Add(true); } else { Crits.Add(false); }
            AttackRoll += (int)Math.Floor(this.BaseAttackBonus[0]) + (int)((this.Dexterity - 10) / 2);
            Attacks.Add(AttackRoll);
        }
        for (int i = 0; i < Attacks.Count(); i++)
        {
            if (Attacks[i] < Enemy.ArmorClass)
            {
                Console.WriteLine($"Attack number {i + 1} missed!");
            }
            else
            {
                int Damage = 0;
                for (int j=1; j<=this.Weapon.DamageDiceNumber; i++)
                {
                    Damage += d(this.Weapon.DamageDiceSize);
                    j++;
                }
                if (Crits[i] == true)
                {
                    Damage = Damage * 2;
                    Console.WriteLine($"Attack number {i + 1} critically hit for {Damage} damage!");
                }
                else
                {
                    Console.WriteLine($"Attack number {i + 1} hit for {Damage} damage!");
                }
                Enemy.HP -= Damage;
            }
        }
    }
}

