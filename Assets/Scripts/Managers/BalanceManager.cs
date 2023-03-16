namespace Game
{
    public class BalanceManager
    {
        private double balance;

        public double Balance => balance;

        public void AddMoney(double amount)
        {
            balance += amount;
        }

        public void SetMoney(double amount)
        {
            balance = amount;
        }

        public bool Spend(double amount)
        {
            if (balance >= amount)
            {
                SetMoney(balance - amount);

                return true;
            }

            return false;
        }
    }
}
