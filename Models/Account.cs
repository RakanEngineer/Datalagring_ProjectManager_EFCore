namespace Datalagring_ProjectManager_EFCore.Models
{
    public class Account
    {
        public string clearingNumber { get; }
        public string accountNumber { get; }
        public string bank { get; }

        public Account(string clearingNumber, string accountNumber, string bank)
        {
            this.clearingNumber = clearingNumber;
            this.accountNumber = accountNumber;
            this.bank = bank;
        }
    }
}