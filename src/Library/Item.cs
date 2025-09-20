namespace Library;
// Represents an item that a character can use in combat.
// The item can provide attack, defense, or healing power to the character.
public class Item
{
    public string Name { get; set; }
    public double AttackPower { get; set; }
    public double DefensePower { get; set; }
    public double HealingPower { get; set; }

    public Item(string name, double attackPower, double defensePower, double healingPower)
    {
        Name = name;
        AttackPower = attackPower;
        DefensePower = defensePower;
        HealingPower = healingPower;
    }
}