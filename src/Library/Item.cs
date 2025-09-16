namespace Library;

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