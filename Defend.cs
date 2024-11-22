public class Defend : IAttackStrategy
{
    public void Execute(Character player, Enemy enemy)
    {
        int reducedDamage = Math.Max(0, enemy.Strength / 2 - player.Defense);
        player.TakeDamage(reducedDamage);  // Gunakan TakeDamage untuk memodifikasi Health
        Console.WriteLine($"You defended! Received {reducedDamage} damage.");
    }
}
