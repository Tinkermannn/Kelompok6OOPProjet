public class Dragon : Enemy
{
    public Dragon()
    {
        Name = "Dragon";
        Health = 200;
        Strength = 25;
        Defense = 15;
        ExperienceValue = 500;
    }

    public override void Attack(Character target)
    {
        Console.WriteLine($"{Name} breathes fire at {target.Name}!");
        target.TakeDamage(Strength);
    }
}