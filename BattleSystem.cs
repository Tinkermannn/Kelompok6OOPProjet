public class BattleSystem
{
    private IBattleStrategy currentStrategy;

    public void SetStrategy(IBattleStrategy strategy)
    {
        currentStrategy = strategy;
    }

    public void ExecuteBattle(Character character, Enemy enemy)
    {
        while (character.Health > 0 && enemy.Health > 0)
        {
            // Display battle status
            Console.WriteLine($"\n{character.Name} vs {enemy.Name}");
            Console.WriteLine($"Your health: {character.Health}/{character.MaxHealth}, Enemy health: {enemy.Health}/{enemy.Health}");
            
            // Prompt player for action
            Console.WriteLine("Choose an action: ");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Defend");
            Console.WriteLine("3. Use item");
            Console.WriteLine("4. Run");

            string action = Console.ReadLine();
            if (action == "1")
            {
                SetStrategy(new NormalAttackStrategy());
                currentStrategy.Execute(character, enemy);
            }
            else if (action == "2")
            {
                SetStrategy(new DefensiveStrategy());
                currentStrategy.Execute(character, enemy);
            }
            else if (action == "3")
            {
                UseItem(character);
            }
            else if (action == "4")
            {
                if (TryToEscape())
                {
                    Console.WriteLine("You successfully escaped!");
                    break;
                }
                else
                {
                    Console.WriteLine("You failed to escape!");
                    enemy.Attack(character);
                }
            }
            else
            {
                Console.WriteLine("Invalid option. Please choose again.");
            }

            // Enemy attacks if it's still alive
            if (enemy.Health > 0)
            {
                enemy.Attack(character);
            }
        }

        if (character.Health <= 0)
        {
            Console.WriteLine("Game Over!");
        }
    }

    private void UseItem(Character character)
    {
        Console.WriteLine("Choose an item to use:");
        List<IItem> items = character.Inventory.GetItems();
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i].Name} - {items[i].Description}");
        }

        int itemIndex = int.Parse(Console.ReadLine()) - 1;
        if (itemIndex >= 0 && itemIndex < items.Count)
        {
            character.UseItem(items[itemIndex]);
        }
        else
        {
            Console.WriteLine("Invalid item.");
        }
    }

    private bool TryToEscape()
    {
        Random rand = new Random();
        return rand.Next(0, 2) == 1;  // 50% chance to escape
    }
}
