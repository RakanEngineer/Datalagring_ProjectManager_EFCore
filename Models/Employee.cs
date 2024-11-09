namespace Datalagring_ProjectManager_EFCore.Models
{
    public class Employee
    {
        public Employee() { } // Parameterless constructor

        public Employee(string firstName, string lastName, string socialSecurityNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
        }
        public Employee(string firstName, string lastName, string socialSecurityNumber, Account paymentAccount)
            :this(firstName, lastName, socialSecurityNumber)
        {
            
            PaymentAccount = paymentAccount;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public Account PaymentAccount { get; set; }
    }
}