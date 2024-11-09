namespace Datalagring_ProjectManager_EFCore.Models
{
    public class Account
    {       

        public Account(string clearingNumber, string accountNumber, string bank)
        {
            ClearingNumber = clearingNumber;
            AccountNumber = accountNumber;
            Bank = bank;
        }
        public int Id { get; protected set; }
        public string ClearingNumber { get; protected set; }
        public string AccountNumber { get; protected set; }
        public string Bank { get; protected set; }
        public int EmployeeId { get; protected set; }

    }
}