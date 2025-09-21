namespace Library;
public class Spell //similar a la clase item, pero diseñada para instanciarse solo como componente dentro de un spellbook
{
    public string Name { get; set; }
    public double AttackPower { get; set; }
    public double DefensePower { get; set; }

    public Spell(string name, double attackPower, double defensePower)
    {
        Name = name;
        AttackPower = attackPower;
        DefensePower = defensePower;
    }
}