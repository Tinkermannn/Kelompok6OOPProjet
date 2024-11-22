public class EnhancedItem : ItemDecorator
{
    public EnhancedItem(IItem item) : base(item) { }

    public override string Name => $"Enhanced {decoratedItem.Name}";
    public override string Description => $"{decoratedItem.Description} (Enhanced)";

    public override void Use(Character character)
    {
        base.Use(character);
        Console.WriteLine($"{Name} provided an additional boost to {character.Name}!");
    }
}