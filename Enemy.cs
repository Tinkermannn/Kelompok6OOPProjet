// Enemy class with Factory Pattern
public abstract class Enemy
{
    public string Name { get; protected set; }
    public int Health { get; protected set; }
    public int Strength { get; protected set; }
    public int Defense { get; protected set; }
    public int ExperienceValue { get; protected set; }

    public abstract void Attack(Character target);

    public void TakeDamage(int damage)
    {
        int effectiveDamage = Math.Max(damage - Defense, 0);
        Health -= effectiveDamage;
        Console.WriteLine($"{Name} took {effectiveDamage} damage. Health: {Health}");

        if (Health <= 0)
        {
            Console.WriteLine($"{Name} has been defeated!");
        }
    }
}
