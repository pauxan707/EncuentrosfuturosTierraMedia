namespace Library;

public class Wizard
{
    public string Name { get; set; }
    public double Life { get; set; }
    public double InitialLife { get; set; } //Vida inicial, se utilizará después para curarlo
    private List<Item> _itemList = new List<Item>(); //Lista de armas, pociones, etc
    
    public Wizard(string name, double life, double initialLife)
    {
        Name = name;
        Life = life;
        InitialLife = life;
    }

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
        Life = InitialLife;
    }

    public void Attack(Wizard target) //Creo que vamos a tener que hacer uno distinto, por eso no lo agregue los otors
    {
        double damage = this.GetAttackPower() - target.GetDefensePower();
        if (damage < 0) damage = 0;
        target.Life -= damage;
        if (target.Life < 0) target.Life = 0;
    }
}