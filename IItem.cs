public interface IItem
{
    string Name { get; }
    string Description { get; }
    void Use(Character character);
}
