


namespace Banking.Domain
{
    public class Account
    {
        private decimal _amount = 5000;
        public void Deposit(decimal amountToDeposit)
        {
            _amount += amountToDeposit;
        }

        public decimal GetBalance()
        {
            return _amount;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            _amount -= amountToWithdraw;
        }
    }
}