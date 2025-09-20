namespace Library;

public class Elves: ICombatant
{
    public string Name { get; set; }
    public double Life { get; set; }
    public double InitialLife { get; set; } //Vida inicial, se utilizará después para curarlo
    private List<Item> _itemList = new List<Item>();

    public Elves(string name, double life, double initialLife)
    {
        Name = name;
        Life = life;
        InitialLife = life;
    }

    public void AddItem(Item item) //Adds an item to the list of items
    {
        _itemList.Add(item);
    }

    public void RemoveItem(Item item) //Removes an item from the list of items
    {
        _itemList.Remove(item);
    }
    public double GetAttackPower() //calculates its total attack power by summing up each item in the list
    {
        double totalPower = 0;
        foreach (var Item in this._itemList)
        {
            totalPower += Item.AttackPower;
        }

        return totalPower;
        
    }

    public double GetHealingPower() //calculates its total healing power by summing up each item in the list
    {
        double totalPower = 0;
        foreach (var Item in this._itemList)
        {
            totalPower += Item.HealingPower;
        }
        return totalPower;
    }
    public double GetDefensePower() //calculates its total defense by summing up each item in the list
    {
        double totalPower = 0;
        foreach (var Item in this._itemList)
        {
            totalPower += Item.DefensePower;
        }
        
        return totalPower;
    }

    public void Heal() //Restores full life 
    {
        Life = InitialLife;
    }

        public void Attack(ICombatant target) //Allows this character to attack
    {
        target.TakeDamage(GetAttackPower());
    }
    public void TakeDamage(double damage) //Handles taking damage
    {
        double RealDamage = damage - GetDefensePower();
        if (RealDamage < 0) RealDamage = 0; //Damage can´t be negative
        Life -= RealDamage;
        if (Life < 0) Life = 0; //Life can't be negative
    }
    public void HealOthers(ICombatant target) //Allows healing others
    {
        target.TakeHeal(GetHealingPower());
    }
    public void TakeHeal(double HP) //Allows getting healed
    {
        Life += HP;
        if (Life > InitialLife)
        {
            Life = InitialLife; //Life can't be higher than InitialLife
        }
    }
}