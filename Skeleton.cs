public class Skeleton : Enemy
{
    public Skeleton()
    {
        Name = "Skeleton";
        Health = 70;
        Strength = 12;
        Defense = 5;
        ExperienceValue = 75;
    }

    public override void Attack(Character target)
    {
        Console.WriteLine($"{Name} attacks {target.Name}!");
        target.TakeDamage(Strength);
    }
}
