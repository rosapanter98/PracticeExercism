public class Player
{
    public int RollDie()
    {
        var rand = new Random();
        int value = rand.Next(1,19);
        return value;
    }

    public double GenerateSpellStrength()
    {
        double max = 100;
        var rand = new Random();
        double value = rand.NextDouble() * max;
        return value;
    }
    
}
