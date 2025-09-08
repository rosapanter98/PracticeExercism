class RemoteControlCar
{
    private int _distanceDriven = 0;
    private int _batteryLeft = 100;
    
    public static RemoteControlCar Buy() =>
        new RemoteControlCar();

    public string DistanceDisplay() => $"Driven {_distanceDriven} meters";

    public string BatteryDisplay() => _batteryLeft > 0 ? $"Battery at {_batteryLeft}%" : "Battery empty";

    public void Drive()
    {
        if (_batteryLeft <= 0) return;
        _batteryLeft -= 1;
        _distanceDriven +=20;
    }
}
