namespace Library;
// Defines the basic contract for any character that can participate in combat.
// Every combatant has life points, can attack, defend, take damage, heal, and heal others.
public interface ICombatant
{
    double Life { get; set; }
    double GetAttackPower();
    double GetDefensePower();
    void TakeDamage(double damage);
    void Attack(ICombatant target);
    void HealOthers(ICombatant target);
    void TakeHeal(double hp);
}