static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        if (DateTime.TryParse(appointmentDateDescription, out var result))
            return result;
    
        throw new ArgumentException("Invalid date format", nameof(appointmentDateDescription));
    }

    public static bool HasPassed(DateTime appointmentDate) =>
        DateTime.Now > appointmentDate;


    public static bool IsAfternoonAppointment(DateTime appointmentDate) =>
        appointmentDate.Hour >= 12 && appointmentDate.Hour < 18;


    public static string Description(DateTime appointmentDate) => 
        new string($"You have an appointment on {appointmentDate}.");

    public static DateTime AnniversaryDate()
    {
        int month = 9;
        int day = 15;
        int year = DateTime.Now.Year;
        return new DateTime(year, month, day);
    }
}
