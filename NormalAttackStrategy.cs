public class NormalAttackStrategy : IBattleStrategy
{
    public void Execute(Character character, Enemy enemy)
    {
        Console.WriteLine($"{character.Name} attacks {enemy.Name} with a normal attack!");
        enemy.TakeDamage(character.Strength);

        if (enemy.Health > 0)
        {
            enemy.Attack(character);
        }
        else
        {
            character.GainExperience(enemy.ExperienceValue);
        }
    }
}