public class Inventory
{
    private List<IItem> items;
    private const int MaxCapacity = 20;

    public Inventory()
    {
        items = new List<IItem>();
    }

    public bool AddItem(IItem item)
    {
        if (items.Count < MaxCapacity)
        {
            items.Add(item);
            Console.WriteLine($"{item.Name} has been added to the inventory.");
            return true;
        }
        Console.WriteLine("Inventory is full!");
        return false;
    }

    public bool RemoveItem(IItem item)
    {
        if (items.Remove(item))
        {
            Console.WriteLine($"{item.Name} has been removed from the inventory.");
            return true;
        }
        Console.WriteLine($"{item.Name} not found in inventory.");
        return false;
    }

    public List<IItem> GetItems()
    {
        return new List<IItem>(items);
    }
}
