static class SavingsAccount
{
    public static float InterestRate(decimal balance) =>
        balance switch
        {
                <0m => 3.213f,
                >=0m and <1000 => 0.5f,
                >=1000m and <5000 => 1.621f,
                _ => 2.475f
        };

    public static decimal Interest(decimal balance) =>
        balance * (decimal)InterestRate(balance) / 100;

    public static decimal AnnualBalanceUpdate(decimal balance) =>
        Interest(balance) + balance;

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;
        while (balance < targetBalance)
        {
            balance = AnnualBalanceUpdate(balance);
            years++;
        }
        return years;
    }
}
