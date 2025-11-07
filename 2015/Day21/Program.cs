using System.Diagnostics;

namespace Day21;

class Program
{
    static void Main(string[] args)
    {
        var store = new List<Item>
        {
            // Weapons
            new() { Name = "Dagger", Cost = 8, Damage = 4, Armor = 0, Slot = ItemSlot.Weapon },
            new() { Name = "Shortsword", Cost = 10, Damage = 5, Armor = 0, Slot = ItemSlot.Weapon },
            new() { Name = "Warhammer", Cost = 25, Damage = 6, Armor = 0, Slot = ItemSlot.Weapon },
            new() { Name = "Longsword", Cost = 40, Damage = 7, Armor = 0, Slot = ItemSlot.Weapon },
            new() { Name = "Greataxe", Cost = 74, Damage = 8, Armor = 0, Slot = ItemSlot.Weapon },

            // Armor
            new() { Name = "Nothing", Cost = 0, Damage = 0, Armor = 0, Slot = ItemSlot.Armor },
            new() { Name = "Leather", Cost = 13, Damage = 0, Armor = 1, Slot = ItemSlot.Armor },
            new() { Name = "Chainmail", Cost = 31, Damage = 0, Armor = 2, Slot = ItemSlot.Armor },
            new() { Name = "Splintmail", Cost = 53, Damage = 0, Armor = 3, Slot = ItemSlot.Armor },
            new() { Name = "Bandedmail", Cost = 75, Damage = 0, Armor = 4, Slot = ItemSlot.Armor },
            new() { Name = "Platemail", Cost = 102, Damage = 0, Armor = 5, Slot = ItemSlot.Armor },

            // Rings
            new() { Name = "Nothing", Cost = 0, Damage = 0, Armor = 0, Slot = ItemSlot.Ring },
            new() { Name = "Damage +1", Cost = 25, Damage = 1, Armor = 0, Slot = ItemSlot.Ring },
            new() { Name = "Damage +2", Cost = 50, Damage = 2, Armor = 0, Slot = ItemSlot.Ring },
            new() { Name = "Damage +3", Cost = 100, Damage = 3, Armor = 0, Slot = ItemSlot.Ring },
            new() { Name = "Defense +1", Cost = 20, Damage = 0, Armor = 1, Slot = ItemSlot.Ring },
            new() { Name = "Defense +2", Cost = 40, Damage = 0, Armor = 2, Slot = ItemSlot.Ring },
            new() { Name = "Defense +3", Cost = 80, Damage = 0, Armor = 3, Slot = ItemSlot.Ring }
        };

        Character player = new("Player");
        Character boss = new("Boss");
        boss.Hp = 109;
        boss.Damage = 8;
        boss.Armor = 2;
        Stopwatch timer = new();

        Console.WriteLine("Run Sim");
        timer.Start();
        RunSim(player, boss, store);
        timer.Stop();
        Console.WriteLine($"Time Elapsed: {timer.Elapsed.TotalMilliseconds} ms");
        Console.WriteLine("\nCalc Rounds");
        timer.Restart();
        CalcRounds(player, boss, store);
        timer.Stop();
        Console.WriteLine($"Time Elapsed: {timer.Elapsed.TotalMilliseconds} ms");


    }

    static void RunSim(Character player, Character boss, List<Item> store)
    {
        int goldSpent = 0;

        List<int> winCosts = new();
        List<int> loseCosts = new();

        foreach (var weapon in store.Where(x => x.Slot == ItemSlot.Weapon).OrderBy(x => x.Cost))
        {
            foreach (var armor in store.Where(x => x.Slot == ItemSlot.Armor).OrderBy(x => x.Cost))
            {
                foreach (var ring in store.Where(x => x.Slot == ItemSlot.Ring).OrderBy(x => x.Cost))
                {
                    foreach (var ring2 in store.Where(x => x.Slot == ItemSlot.Ring).OrderBy(x => x.Cost))
                    {
                        Reset(player, boss);
                        player.Damage = weapon.Damage + ring.Damage + ring2.Damage;
                        player.Armor = armor.Armor + ring.Armor + ring2.Armor;
                        if (ring == ring2 && ring.Name != "Nothing") continue;
                        player.EquippedItems.Weapon = weapon;
                        player.EquippedItems.Armor = armor;
                        player.EquippedItems.Ring1 = ring;
                        player.EquippedItems.Ring2 = ring2;
                        goldSpent = weapon.Cost + armor.Cost + ring.Cost + ring2.Cost;

                        while (player.Hp > 0 && boss.Hp > 0)
                        {
                            PlayRound(player, boss);
                        }

                        if (player.Hp <= 0 || boss.Hp <= 0)
                        {
                            if (boss.Hp <= 0)
                            {
                                //Console.WriteLine($"Player: {player.Hp} Boss: {boss.Hp}");
                                //Console.WriteLine($"Total Gold Spent: {goldSpent}");
                                winCosts.Add(goldSpent);
                            }
                            else
                            if (player.Hp <= 0)
                            {
                                loseCosts.Add(goldSpent);
                            }

                        }



                    }
                }
            }

        }
        Console.WriteLine($"Part 1: Min Gold Spent and Won: {winCosts.Min()}");
        Console.WriteLine($"Part 2: Max Gold Spent and Lost: {loseCosts.Max()}");
    }
    static void CalcRounds(Character player, Character boss, List<Item> store)
    {
        int goldSpent = 0;

        List<int> winCosts = new();
        List<int> loseCosts = new();

        foreach (var weapon in store.Where(x => x.Slot == ItemSlot.Weapon).OrderBy(x => x.Cost))
        {
            foreach (var armor in store.Where(x => x.Slot == ItemSlot.Armor).OrderBy(x => x.Cost))
            {
                foreach (var ring in store.Where(x => x.Slot == ItemSlot.Ring).OrderBy(x => x.Cost))
                {
                    foreach (var ring2 in store.Where(x => x.Slot == ItemSlot.Ring).OrderBy(x => x.Cost))
                    {
                        Reset(player, boss);
                        player.Damage = weapon.Damage + ring.Damage + ring2.Damage;
                        player.Armor = armor.Armor + ring.Armor + ring2.Armor;
                        if (ring == ring2 && ring.Name != "Nothing") continue;
                        player.EquippedItems.Weapon = weapon;
                        player.EquippedItems.Armor = armor;
                        player.EquippedItems.Ring1 = ring;
                        player.EquippedItems.Ring2 = ring2;
                        goldSpent = weapon.Cost + armor.Cost + ring.Cost + ring2.Cost;


                        int playerRounds = (int)Math.Round(boss.Hp / (double)Math.Max(player.Damage - boss.Armor, 1));
                        int bossRounds = (int)Math.Round(player.Hp / (double)Math.Max(boss.Damage - player.Armor, 1));
                        if (playerRounds < bossRounds)
                        {
                            winCosts.Add(goldSpent);
                        }
                        else
                        {
                            loseCosts.Add(goldSpent);
                        }

                    }
                }
            }

        }
        Console.WriteLine($"Part 1: Min Gold Spent and Won: {winCosts.Min()}");
        Console.WriteLine($"Part 2: Max Gold Spent and Lost: {loseCosts.Max()}");
    }
    static void Reset(Character player, Character boss)
    {
        player.Hp = 100;
        boss.Hp = 109;
    }
    static void PlayRound(Character player, Character boss)
    {
        int dmg = player.Damage - boss.Armor;
        if (dmg < 1) dmg = 1;
        boss.Hp -= dmg;

        if (boss.Hp <= 0)
        {
            return;
        }

        dmg = boss.Damage - player.Armor;
        if (dmg < 1) dmg = 1;

        player.Hp -= dmg;
    }
}





public class Character(string Name)
{
    public string Name { get; set; } = Name;
    public int Hp { get; set; } = 100;
    public int Damage { get; set; }
    public int Armor { get; set; }
    public PaperDoll EquippedItems { get; set; } = new();
    public class PaperDoll
    {
        public Item Weapon { get; set; } = new Item() { Name = "NULL", Slot = ItemSlot.Weapon };
        public Item Armor { get; set; } = new Item() { Name = "NULL", Slot = ItemSlot.Armor };
        public Item Ring1 { get; set; } = new Item() { Name = "NULL", Slot = ItemSlot.Ring };
        public Item Ring2 { get; set; } = new Item() { Name = "NULL", Slot = ItemSlot.Ring };
    }
}

public class Item()
{
    public string Name { get; set; } = string.Empty;
    public int Cost { get; set; }
    public int Damage { get; set; }
    public int Armor { get; set; }
    public ItemSlot Slot { get; set; }
}
public enum ItemSlot

{
    Weapon,
    Armor,
    Ring
}