class Program
{
    static void Main(string[] args)
    {
        GameManager game = new GameManager();
        Console.Write("Enter your character's name: ");
        string playerName = Console.ReadLine();
        game.StartNewGame(playerName);

        // Add some items to the inventory
        var sword = new WeaponItem("Sword", "A sharp blade that increases attack.", 10);
        var shield = new DefenseItem("Shield", "A sturdy shield that increases defense.", 5);

        Character.GetInstance().Inventory.AddItem(sword);
        Character.GetInstance().Inventory.AddItem(shield);

        // Start the adventure
        game.StartAdventure();
    }
}
