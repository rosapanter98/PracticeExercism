class RemoteControlCar
{
    public int Speed { get; set; }
    public int BatteryDrain { get; set; }

    private int _distanceDriven;
    private int _batteryPercentage;

    public int CurrentBattery => _batteryPercentage; // read-only public property

    public RemoteControlCar(int speed, int batteryDrain)
    {
        Speed = speed;
        BatteryDrain = batteryDrain;

        _distanceDriven = 0;
        _batteryPercentage = 100;
    }

    public bool BatteryDrained()
    {
        return _batteryPercentage < BatteryDrain;
    }

    public int DistanceDriven()
    {
        return _distanceDriven;
    }

    public void Drive()
    {
        if (!BatteryDrained())
        {
            _distanceDriven += Speed;
            _batteryPercentage -= BatteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }
}


class RaceTrack
{
    public int Distance {get; set;}

    public RaceTrack (int distance)
    {
        Distance = distance;
    }

    
    public bool TryFinishTrack(RemoteControlCar car)
    {
        int maxDistance = (car.CurrentBattery / car.BatteryDrain) * car.Speed;
        return maxDistance >= Distance;
    }

}
