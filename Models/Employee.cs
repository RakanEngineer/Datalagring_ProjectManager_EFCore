namespace Datalagring_ProjectManager_EFCore.Models
{
    public class Employee
    {      

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
        public int Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string SocialSecurityNumber { get; protected set; }
        public Account PaymentAccount { get; protected set; }
        //public int DepartmentId { get; protected set; }
        //public Department Department { get; protected set; }

    }
}