public class Goblin : Enemy
{
    public Goblin()
    {
        Name = "Goblin";
        Health = 50;
        Strength = 8;
        Defense = 3;
        ExperienceValue = 50;
    }

    public override void Attack(Character target)
    {
        Console.WriteLine($"{Name} attacks {target.Name}!");
        target.TakeDamage(Strength);
    }
}