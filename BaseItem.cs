public class BaseItem : IItem
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }

    public virtual void Use(Character character)
    {
        Console.WriteLine($"{Name} used by {character.Name}.");
    }
}
