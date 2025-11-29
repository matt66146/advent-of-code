namespace Day22;

class Program
{
    static void Main(string[] args)
    {
        var player = new Wizard("Matt", 50, 0, 0, 500);
        var boss = new Character("Boss", 51, 9, Armor: 0);

        List<int> manaSpent = new List<int>();

        foreach (var spell in player.Spells)
        {
            if (spell.Name == "Shield")
            {
                Console.Write("");
            }
            StartTurn(CopyPlayer(player), CopyBoss(boss), spell, manaSpent);
        }
        Console.WriteLine(manaSpent.Count);
        manaSpent.Sort();
        Console.WriteLine(string.Join(",", manaSpent));
        Console.WriteLine($"Min Mana Spent: {manaSpent[0]}");

    }

    static void StartTurn(Wizard player, Character boss, Spell spell, List<int> manaSpent)
    {
        if (player.ActiveEffects.Count > 1)
        {
            Console.Write("");
        }
        if (player.ActiveEffects.Count > 0 && spell.Name == "Recharge")
        {
            Console.Write("");
        }
        //Check if spell can be cast again
        var e = boss.ActiveEffects.Find(effect => effect.Name == spell.Name) ?? player.ActiveEffects.Find(effect => effect.Name == spell.Name);

        if (e is not null)
        {
            if (e.Duration > 1) return;
        }

        //Check if player has enough mana
        if (player.Mana < spell.ManaCost) return;

        TickEffects(player, boss);

        //Spend Mana
        player.Mana -= spell.ManaCost;
        player.ManaSpent += spell.ManaCost;

        if (manaSpent.Count > 0)
        {
            if (player.ManaSpent >= manaSpent.First()) return;
        }

        //Non effect based spell
        if (spell.Duration == 0)
        {
            boss.Hp -= spell.Damage;
            player.Hp += spell.Healing;
        }
        //Effect based spell
        else
        {
            if (spell.Damage > 0)
            {
                boss.ActiveEffects.Add(new Spell(spell.Name, spell.Damage, spell.Healing, spell.Armor, spell.Duration, spell.ManaCost, spell.ManaGain));

            }
            else
            {
                player.ActiveEffects.Add(new Spell(spell.Name, spell.Damage, spell.Healing, spell.Armor, spell.Duration, spell.ManaCost, spell.ManaGain));
            }
        }

        //boss turn
        TickEffects(player, boss);
        if (boss.Hp > 0)
        {

            player.Hp -= Math.Max(boss.Damage - player.Armor, 1);
            if (player.Hp <= 0)
            {
                return;
            }
        }
        else
        {
            manaSpent.Add(player.ManaSpent);
            manaSpent.Sort();
            Console.WriteLine(manaSpent.First());
            return;
        }


        //if still alive
        foreach (var nextSpell in player.Spells)
        {
            if (spell.Name == "Recharge" && player.Hp == 48)
            {
                Console.Write("");
            }
            StartTurn(CopyPlayer(player), CopyBoss(boss), nextSpell, manaSpent);
        }


    }


    static void TickEffects(Wizard player, Character boss)
    {
        //Check player effects
        var effectsToRemove = new List<Spell>();
        foreach (var effect in player.ActiveEffects)
        {
            player.Mana += effect.ManaGain;
            player.Armor = effect.Armor;
            effect.Duration--;
            if (effect.Duration == 0) effectsToRemove.Add(effect);
        }
        foreach (var effect in effectsToRemove)
        {
            player.ActiveEffects.Remove(effect);
            player.Armor -= effect.Armor;
        }

        //Check boss effects
        effectsToRemove = new List<Spell>();
        foreach (var effect in boss.ActiveEffects)
        {
            boss.Hp -= effect.Damage;
            effect.Duration--;
            if (effect.Duration == 0) effectsToRemove.Add(effect);
        }
        foreach (var effect in effectsToRemove)
        {
            boss.ActiveEffects.Remove(effect);
        }

    }

    static Wizard CopyPlayer(Wizard player)
    {
        var newPlayer = new Wizard(player.Name, player.Hp, player.Damage, player.Armor, player.Mana);
        newPlayer.ManaSpent = player.ManaSpent;
        foreach (var effect in player.ActiveEffects)
        {

            newPlayer.ActiveEffects.Add(new Spell(effect.Name, effect.Damage, effect.Healing, effect.Armor, effect.Duration, effect.ManaCost, effect.ManaGain));
        }
        return newPlayer;
    }
    static Character CopyBoss(Character boss)
    {
        var newBoss = new Character(boss.Name, boss.Hp, boss.Damage, boss.Armor);
        foreach (var effect in newBoss.ActiveEffects)
        {
            newBoss.ActiveEffects.Add(new Spell(effect.Name, effect.Damage, effect.Healing, effect.Armor, effect.Duration, effect.ManaCost, effect.ManaGain));
        }
        return newBoss;
    }
}

public class Character
{
    public string Name { get; set; }
    public int Hp { get; set; }
    public int Damage { get; set; }
    public int Armor { get; set; }
    public List<Spell> ActiveEffects { get; set; } = new();

    public Character(string Name, int Hp, int Damage, int Armor)
    {
        this.Name = Name;
        this.Hp = Hp;
        this.Damage = Damage;
        this.Armor = Armor;
    }
}

public class Wizard : Character
{
    public int Mana { get; set; }
    public List<Spell> Spells { get; set; }

    public int ManaSpent { get; set; } = 0;
    public Wizard(string Name, int Hp, int Damage, int Armor, int Mana) : base(Name, Hp, Damage, Armor)
    {
        this.Mana = Mana;
        Spells = new()
        {
            new Spell("Magic Missile",4,0,0,0,53,0),
            new Spell("Drain",2,2,0,0,73,0),
            new Spell("Shield",0,0,7,6,113,0),
            new Spell("Poison",3,0,0,6,173,0),
            new Spell("Recharge",0,0,0,5,229,101)
        };
    }


}
public class Spell
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Healing { get; set; }
    public int Armor { get; set; }
    public int Duration { get; set; }
    public int ManaCost { get; set; }
    public int ManaGain { get; set; }

    public Spell(string Name, int Damage, int Healing, int Armor, int Duration, int ManaCost, int ManaGain)
    {
        this.Name = Name;
        this.Damage = Damage;
        this.Healing = Healing;
        this.Armor = Armor;
        this.Duration = Duration;
        this.ManaCost = ManaCost;
        this.ManaGain = ManaGain;
    }
}

