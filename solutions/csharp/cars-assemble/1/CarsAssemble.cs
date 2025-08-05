static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        ValidateSpeed(speed);
        return speed switch
        {
            0 => 0.0,
            >= 1 and <= 4 => 1.0,
            >= 5 and <= 8 => 0.9,
            9 => 0.8,
            _ => 0.77
        };
    }

    public static double ProductionRatePerHour(int speed)
    {
        ValidateSpeed(speed);
        return SuccessRate(speed) * speed * 221;
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        ValidateSpeed(speed);
        if (speed == 0) return 0;

        double itemsPerMinute = speed * 221 / 60.0 * SuccessRate(speed);
        return (int)itemsPerMinute;
    }

    private static void ValidateSpeed(int speed)
    {
        if (speed < 0 || speed > 10)
            throw new ArgumentOutOfRangeException(nameof(speed), "Speed must be between 0 and 10 inclusive.");
    }

}
