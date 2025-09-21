using Library;

class Program
{
    static void Main()
    {
        Wizard yanfei = new Wizard("Yanfei", 150, 150);
        Wizard qiqi = new Wizard("Qiqi", 100, 100);
    
        Item espada = new Item("Rey de los Mares", 30, 10, 0);
        qiqi.AddItem(espada);

        Spell fireball = new Spell("Fireball", 100, 0);
        qiqi.AddSpell(fireball);
        
        Item grimorioReal = new Item("Grimorio Real", 20, 0, 15);
        yanfei.AddItem(grimorioReal);

        Console.WriteLine($"Vida de Yanfei antes: {yanfei.Life}");

        qiqi.Attack(yanfei); 
        Console.WriteLine($"Vida de Yanfei después: {yanfei.Life}");

        yanfei.Heal();           
        Console.WriteLine($"Vida de Yanfei después de curar: {yanfei.Life}");
    }
}
