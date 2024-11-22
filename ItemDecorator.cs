public abstract class ItemDecorator : IItem
{
    protected IItem decoratedItem;

    public ItemDecorator(IItem item)
    {
        decoratedItem = item;
    }

    public virtual string Name => decoratedItem.Name;
    public virtual string Description => decoratedItem.Description;

    public virtual void Use(Character character)
    {
        decoratedItem.Use(character);
    }
}