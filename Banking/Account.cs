namespace Banking
{
    public class Account
    {
        public int Balance { get; set; }

        public bool CanWithdraw(int amount)
        {
            return amount < Balance;
        }
    }
}
