class BirdCount
{
    private int[] _birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        _birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new int[] {0, 2, 5, 3, 7, 8, 4};
    }

    public int Today()
    {
        return _birdsPerDay[^1];
    }
    
    public void IncrementTodaysCount()
    {
        _birdsPerDay[^1]++;
    }

    public bool HasDayWithoutBirds()
    {
        return _birdsPerDay.Contains(0);
    }

    public int CountForFirstDays(int numberOfDays)
    {
        return _birdsPerDay.Take(numberOfDays).Sum();
    }

    public int BusyDays()
    {
        return _birdsPerDay.Count(day => day >= 5);
    }
}
