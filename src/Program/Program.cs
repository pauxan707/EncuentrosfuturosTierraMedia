using Library;

class Program
{
    static void Main() ///prueba
    {
        Wizard yanfei = new Wizard("Yanfei", 150, 150);
        Wizard qiqi = new Wizard("Qiqi", 100, 100);
        
        Item espada = new Item("Espada", 30, 10, 0);
        qiqi.AddItem(espada);

        Console.WriteLine($"Vida de Yanfei antes: {yanfei.Life}");

        qiqi.Attack(yanfei); 
        Console.WriteLine($"Vida de Yanfei después: {yanfei.Life}");

        yanfei.Heal();           
        Console.WriteLine($"Vida de Yanfei después de curar: {yanfei.Life}");
    }   
}
