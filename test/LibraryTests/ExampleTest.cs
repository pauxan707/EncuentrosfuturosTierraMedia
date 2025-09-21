using Library;

namespace LibraryTests;

public class Tests
{
    [Test]
    public void TestAttack() //Testing if the attack, items, item list and species are working properly
    {
        var wizard = new Wizard("Mark The Fire Wizard", 100, 100);
        var dwarf = new Dwarf("Napoleon Bonaparte", 100, 100);
        var item1 = new Item("Nuclear bomb", 100, 0, 0);
        var item2 = new Item("A white horse", 10, 1, 0);
        wizard.AddItem(item1);
        dwarf.AddItem(item2);
        wizard.Attack(dwarf);
        Assert.AreEqual(1, dwarf.Life); 
    }
    [Test]
    public void TestLife() //Tests if life doesn't become negative after getting attacked
    {
        var wizard = new Wizard("Mark The Fire Wizard", 100, 100);
        var dwarf = new Dwarf("Napoleon Bonaparte", 100, 100);
        var item1 = new Item("Nuclear bomb", 500, 0, 0);
        var item2 = new Item("A white horse", 10, 1, 0);
        wizard.AddItem(item1);
        dwarf.AddItem(item2);
        wizard.Attack(dwarf);
        Assert.AreEqual(0, dwarf.Life);
    }
    [Test]
    public void TestOverHealing() //Tests if TakeHeal doesn't exceed character's initial life
    {
        var elve1 = new Elves("Mark Zuckerberg", 100, 100);
        var dwarf1 = new Dwarf("Lionel Messi", 30, 100);
        var item1 = new Item("Magic life potion", 0, 0, 500);
        elve1.AddItem(item1);
        elve1.HealOthers(dwarf1);
        Assert.AreEqual(100, dwarf1.Life);
    }
    [Test]
    public void TestHeal() //Tests if HealOthers and TakeHeal raises target's life properly and if elves class is working
    {
        var elve1 = new Elves("Mark Zuckerberg", 100, 100);
        var dwarf1 = new Dwarf("Lionel Messi", 30, 100);
        var item1 = new Item("Fish and chips", 0, 0, 50);
        elve1.AddItem(item1);
        elve1.HealOthers(dwarf1);
        Assert.AreEqual(80, dwarf1.Life);
    }
    [Test]
    public void TestMaxHeal() 
    {
        var elve1 = new Elves("Mark Zuckerberg", 1, 100);
        elve1.Heal();
        Assert.AreEqual(100, elve1.Life);
    }
    [Test]
    public void TestDefense() //Tests if the defense of a character can fully block an attack, without reducing his life
    {
        var wizard1 = new Wizard("Anto the ice wizard",  100, 100);
        var dwarf1 = new Dwarf("Almighty Napoleon Bonaparte", 100, 100);
        var item1 = new Item("Magical shield", 0, 1000, 0);
        var item2 = new Item("Snow ball", 5, 0, 0);
        dwarf1.AddItem(item1);
        wizard1.AddItem(item2);
        wizard1.Attack(dwarf1);
        Assert.AreEqual(100,dwarf1.Life);
    }
}