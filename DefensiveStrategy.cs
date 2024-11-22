public class DefensiveStrategy : IBattleStrategy
{
    public void Execute(Character character, Enemy enemy)
    {
        Console.WriteLine($"{character.Name} defends, reducing incoming damage!");
        character.IncreaseDefense(5);

        enemy.Attack(character);

        character.IncreaseDefense(-5); // Revert defense increase
    }
}