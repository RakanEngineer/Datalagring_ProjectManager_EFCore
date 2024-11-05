namespace Datalagring_ProjectManager_EFCore.Models
{
    public class Employee
    {
        public string firstName { get; }
        public string lastName {  get; }
        public string socialSecurityNumber { get; }
        public Account PaymentAccount { get; }

        public Employee(string? firstName, string? lastName, string? socialSecurityNumber, Account paymentAccount)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.socialSecurityNumber = socialSecurityNumber;
        }

       
    }
}