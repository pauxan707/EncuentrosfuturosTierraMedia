namespace Library;

public class Wizard
{
    public string Name { get; set; }
    public double ILife { get; set; }


    public Wizard(string name, double ilife)
    {
        Name = name;
        ILife = ilife;
    }

    private List<Item> _itemList = new List<Item>(); //Lista de armas, pociones, etc

    public void AddItem(Item item)
    {
        _itemList.Add(item);
    }

    public void RemoveItem(Item item)
    {
        _itemList.Remove(item);
    }
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
    public void Heal()
    {
        Life = ILife;
    }
}