public class WeaponItem : BaseItem
{
    public int AttackBonus { get; private set; }

    public WeaponItem(string name, string description, int attackBonus)
    {
        Name = name;
        Description = description;
        AttackBonus = attackBonus;
    }

    public override void Use(Character character)
    {
        base.Use(character);
        character.IncreaseStrength(AttackBonus);  // Menggunakan metode untuk meningkatkan Strength
    }
}
