class RemoteControlCar
{
    public int Speed { get; }
    public int BatteryDrain { get; }

    private int _distanceDriven;
    private int _batteryPercentage = 100;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        if (speed <= 0) throw new ArgumentOutOfRangeException(nameof(speed));
        if (batteryDrain <= 0 || batteryDrain > 100) throw new ArgumentOutOfRangeException(nameof(batteryDrain));

        Speed = speed;
        BatteryDrain = batteryDrain;
    }

    public bool BatteryDrained() =>
        _batteryPercentage < BatteryDrain;

    public int DistanceDriven() => 
        _distanceDriven;

    public void Drive()
    {
        if (!BatteryDrained())
        {
        _distanceDriven += Speed;
        _batteryPercentage -= BatteryDrain;             
        }
    }

    public static RemoteControlCar Nitro() =>
        new RemoteControlCar(50, 4);
}

class RaceTrack
{
    public int Distance { get; }

    public RaceTrack(int distance)
    {
        Distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        var maxDrives = 100 / car.BatteryDrain;
        var maxDistance = maxDrives * car.Speed;
        return maxDistance >= Distance;
    }
}
