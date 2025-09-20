using Library;

namespace LibraryTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestAttack() //Testing if the attack, items, item list and species are working properly
    {
        var wizard = new Wizard("Mark The Firewizard", 100, 100);
        var dwarf = new Dwarf("Napoleon Bonaparte", 100, 100);
        var Item = new Item("Nuclear bomb", 100, 0, 0);
        var item2 = new Item("A white horse", 10, 1, 0);
        wizard.AddItem(Item);
        dwarf.AddItem(item2);
        wizard.Attack(dwarf);
        Assert.AreEqual(1, dwarf.Life);
    }
    public void TestHeal() //Tests if HealOthers raises target's life properly and if elves class is working
    {
        var elve1 = new Elves("Mark Zuckerberg", 100, 100);
        var dwarf1 = new Dwarf("Lionel Messi", 30, 100);
        var item1 = new Item("Fish and chips", 0, 0, 50);
        elve1.AddItem(item1);
        elve1.HealOthers(dwarf1);
        Assert.AreEqual(80, dwarf1.Life);
    }
}