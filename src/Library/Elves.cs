namespace Library;

public class Elves
{
    public string Name { get; set; }
    public double Life { get; set; }


    public Elves(string name, double life)
    {
        Name = name;
        Life = life;
    }

    private List<Item> _itemList = new List<Item>();
    public double GetAttackPower()
    {
        double totalPower = 0;
        foreach (var Item in this._itemList)
        {
            totalPower += Item.AttackPower;
        }

        return totalPower;
    }
    public double GetHealingPower()
        {
            double totalPower = 0;
            foreach (var Item in this._itemList)
            {
                totalPower += Item.HealingPower;
            }
    
            return totalPower;
        }
    public double GetDefensePower()
    {
        double totalPower = 0;
        foreach (var Item in this._itemList)
        {
            totalPower += Item.DefensePower;
        }

        return totalPower;
    }
}