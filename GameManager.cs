public class GameManager
{
    private Character player;
    private BattleSystem battleSystem;

    public GameManager()
    {
        player = Character.GetInstance();
        battleSystem = new BattleSystem();
    }

    public void StartNewGame(string playerName)
    {
        player.Initialize(playerName);
        Console.WriteLine($"Welcome, {playerName}! Your adventure begins.");
    }

    public void SaveGame()
    {
        Console.WriteLine("Game saved!");
    }

    public void LoadGame()
    {
        Console.WriteLine("Game loaded!");
    }

    public void StartAdventure()
    {
        Random rand = new Random();
        while (player.Health > 0)
        {
            // Random enemy encounter
            Enemy enemy = rand.Next(3) switch
            {
                0 => new Goblin(),
                1 => new Skeleton(),
                _ => new Dragon()
            };

            Console.WriteLine($"\nA wild {enemy.Name} appears!");

            // Choose action: Attack or Defend
            Console.WriteLine("Choose your action: (1) Attack (2) Defend (3) Use item (4) Run");
            string action = Console.ReadLine();

            if (action == "1")
            {
                battleSystem.SetStrategy(new NormalAttackStrategy());
            }
            else if (action == "2")
            {
                battleSystem.SetStrategy(new DefensiveStrategy());
            }
            else if (action == "3")
            {
                battleSystem.SetStrategy(new NormalAttackStrategy());  // Default to normal attack if using item
            }

            // Execute battle
            battleSystem.ExecuteBattle(player, enemy);

            if (player.Health <= 0)
            {
                Console.WriteLine("Game Over!");
                break;
            }

            // Ask player to continue
            Console.WriteLine("\nDo you want to continue your adventure? (y/n)");
            string continueAdventure = Console.ReadLine();
            if (continueAdventure.ToLower() != "y")
            {
                break;
            }
        }
    }
}
