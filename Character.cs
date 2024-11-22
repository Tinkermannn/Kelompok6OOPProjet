public class Character
{
    private static Character instance;
    private static readonly object lockObject = new object();

    public string Name { get; private set; }
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public int Strength { get; set; }  // Menambahkan setter untuk Strength
    public int Defense { get; set; }   // Menambahkan setter untuk Defense
    public int Level { get; private set; }
    public int Experience { get; private set; }
    public Inventory Inventory { get; private set; }

    private Character()
    {
        Inventory = new Inventory();
        Level = 1;
        Experience = 0;
        InitializeBaseStats();
    }

    private void InitializeBaseStats()
    {
        MaxHealth = 100;
        Health = MaxHealth;
        Strength = 10;
        Defense = 5;
    }

    public static Character GetInstance()
    {
        if (instance == null)
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Character();
                }
            }
        }
        return instance;
    }

    public void Initialize(string name)
    {
        Name = name;
    }

    public void GainExperience(int amount)
    {
        Experience += amount;
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        int experienceNeeded = Level * 100;
        while (Experience >= experienceNeeded)
        {
            LevelUp();
            experienceNeeded = Level * 100;
        }
    }

    private void LevelUp()
    {
        Level++;
        MaxHealth += 20;
        Health = MaxHealth;
        Strength += 5;
        Defense += 3;
        Experience -= (Level - 1) * 100;
        Console.WriteLine($"{Name} leveled up to level {Level}!");
    }

    public void TakeDamage(int damage)
    {
        int effectiveDamage = Math.Max(damage - Defense, 0);
        Health -= effectiveDamage;
        Console.WriteLine($"{Name} took {effectiveDamage} damage. Health: {Health}/{MaxHealth}");

        if (Health <= 0)
        {
            Console.WriteLine($"{Name} has been defeated!");
        }
    }

    // Method to increase Strength
    public void IncreaseStrength(int amount)
    {
        Strength += amount;
        Console.WriteLine($"{Name}'s strength is now {Strength}.");
    }

    // Method to increase Defense
    public void IncreaseDefense(int amount)
    {
        Defense += amount;
        Console.WriteLine($"{Name}'s defense is now {Defense}.");
    }

    // Method to use an item
    public void UseItem(IItem item)
    {
        Console.WriteLine($"{Name} uses {item.Name}: {item.Description}");
        item.Use(this);
    }
}
