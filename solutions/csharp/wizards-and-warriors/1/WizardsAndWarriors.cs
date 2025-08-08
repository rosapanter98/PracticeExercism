abstract class Character
{
    public string CharacterType { get; }

    protected Character(string characterType)
    {
        CharacterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() => $"Character is a {CharacterType}";
}


class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable()? 10 : 6;
    }
}

class Wizard : Character
{
    private bool _prepared;
    
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        return _prepared ? 12 : 3;
    }

    public void PrepareSpell()
    {
        _prepared = true;
    }
    public override bool Vulnerable()
    {
        return !_prepared;
    }

}
