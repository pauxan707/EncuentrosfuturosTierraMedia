public interface ICombatant
{
    double Life { get; set; }
    double GetAttackPower();
    double GetDefensePower();
    void TakeDamage(double damage);
    void Attack(ICombatant target);
    void HealOthers(ICombatant target);
    void TakeHeal(double HP);
}