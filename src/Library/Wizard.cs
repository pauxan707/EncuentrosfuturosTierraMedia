namespace Library;
/// <summary>
/// Representa un Wizard que implementa ICombatant para definir acciones comunes de combate.
/// 
/// SRP: Esta clase solo maneja los comportamientos específicos de wizards, solo cambiaría si se cambia lo que es un wizard.
/// Expert: Wizard es experto en su propia información (items, vida, poderes)
/// </summary>
/// NOTA: Todos los demás métodos en las otras clases tienen las mismas justificaciones que en Wizard
/// porque implementan exactamente la misma lógica. Esto se alinea con LSP.
public class Wizard : ICombatant
{
    public string Name { get; set; }
    public double Life { get; set; } //Current life
    public double InitialLife { get; set; } //Initial life
    private List<Item> _itemList = new List<Item>(); //List of weapons, potions, etc
    private List<Spell> _spellBook = new List<Spell>(); //spellbook, list of all the wizard´s spells

    public Wizard(string name, double life, double initialLife)
    {
        Name = name;
        Life = life;
        InitialLife = initialLife;
        
    }

    public void AddItem(Item item) //Adds an item to the wizard's inventory (_itemslist)
    {
        _itemList.Add(item);
    }
    
    public void AddSpell(Spell spell) 
    {
        _spellBook.Add(spell);
    }

    public void RemoveItem(Item item) //Removes an item
    {
        _itemList.Remove(item);
    }
    
    public void RemoveSpell(Spell spell) 
    {
        _spellBook.Remove(spell);
    }
    
    public double GetAttackPower() //Calculates its total attack power by summing up each item in the list
    {
        double totalPower = 0;
        foreach (var item in this._itemList)
        {
            totalPower += item.AttackPower;
        }

        foreach (var spell in this._spellBook)
        {
            totalPower += spell.AttackPower;
        }
        return totalPower;
    }
    
    /// <summary>
    /// Expert: Wizard conoce sus items que curan y puede calcular su poder total
    /// SRP: Método enfocado solo en calcular poder de curación
    /// </summary>
    public double GetHealingPower() //Calculates its total healing power by summing up each item in the list
    {
        double totalPower = 0;
        foreach (var item in this._itemList)
        {
            totalPower += item.HealingPower;
        }
        return totalPower;
    }
    
    public double GetDefensePower() //Calculates its total defense by summing up each item in the list
    {
        double totalPower = 0;
        foreach (var item in this._itemList)
        {
            totalPower += item.DefensePower;
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
        double realDamage = damage - GetDefensePower();
        if (realDamage < 0) realDamage = 0; //Ensures that the damage value cannot be negative
        Life -= realDamage;
        if (Life < 0) Life = 0; //Life can't be negative
    }
    
    /// <summary>
    /// Expert: Wizard conoce su poder de curación y sabe cómo usarlo
    /// Low Coupling Y Polymorphism: Funciona con cualquier ICombatant
    /// </summary>
    public void HealOthers(ICombatant target) //Allows healing others
    {
        target.TakeHeal(GetHealingPower());
    }
    public void TakeHeal(double hp) //Allows getting healed
    {
        Life += hp;
        if (Life > InitialLife)
        {
            Life = InitialLife; //Life can't be higher than InitialLife
        }
    }
}