namespace Library;
/// <summary>
/// Representa un Elve que implementa ICombatant para definir acciones comunes de combate.
/// 
/// SRP: Esta clase solo maneja los comportamientos específicos de elves
/// Expert: Elves es experto en su propia información (items, vida, poderes)
/// </summary>
public class Elves: ICombatant
{
    public string Name { get; set; }
    public double Life { get; set; } //Current life
    public double InitialLife { get; set; } //Initial life
    private List<Item> _itemList = new List<Item>(); //List of weapons, potions, etc

    public Elves(string name, double life, double initialLife)
    {
        Name = name;
        Life = life;
        InitialLife = initialLife;
    }

    public void AddItem(Item item) //Adds an item to the elves inventory (_itemslist)
    {
        _itemList.Add(item);
    }

    public void RemoveItem(Item item) //Removes an item 
    {
        _itemList.Remove(item);
    }
    
    public double GetAttackPower() //Calculates its total attack power by summing up each item in the list
    {
        double totalPower = 0;
        foreach (var Item in this._itemList)
        {
            totalPower += Item.AttackPower;
        }
        return totalPower;
    }

    public double GetHealingPower() //Calculates its total healing power by summing up each item in the list
    {
        double totalPower = 0;
        foreach (var Item in this._itemList)
        {
            totalPower += Item.HealingPower;
        }
        return totalPower;
    }
    
    public double GetDefensePower() //Calculates its total defense by summing up each item in the list
    {
        double totalPower = 0;
        foreach (var Item in this._itemList)
        {
            totalPower += Item.DefensePower;
        }
        return totalPower;
    }

    public void Heal() //Restores life to their inicial value
    {
        if (Life > 0)
        {
            Life = InitialLife;
        }
    }

    public void Attack(ICombatant target) //Allows this character to attack
    {
        target.TakeDamage(GetAttackPower());
    }
    
    public void TakeDamage(double damage) //Handles taking damage
    {
        double RealDamage = damage - GetDefensePower();
        if (RealDamage < 0) RealDamage = 0; //Ensures that the damage value cannot be negative
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