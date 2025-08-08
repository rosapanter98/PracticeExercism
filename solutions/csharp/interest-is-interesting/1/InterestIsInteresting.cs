static class SavingsAccount
{
    public static float InterestRate(decimal balance) => balance switch
    {
        < 0m                    => 3.213f,
        >= 0m    and < 1000m    => 0.5f,
        >= 1000m and < 5000m    => 1.621f,
        >= 5000m                => 2.475f
    };

    public static decimal Interest(decimal balance)
    {
        float ratePercent = InterestRate(balance);
        return balance * (decimal)ratePercent / 100m;
    }

    public static decimal AnnualBalanceUpdate(decimal balance) =>
        balance + Interest(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        if (balance >= targetBalance) return 0;

        int years = 0;
        while (balance < targetBalance)
        {
            var next = AnnualBalanceUpdate(balance);
            if (next <= balance) // no progress (e.g., 0% or negative growth toward higher target)
                throw new InvalidOperationException("Balance cannot reach the target with current interest rules.");

            balance = next;
            years++;
        }
        return years;
    }
}
