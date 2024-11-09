using Datalagring_ProjectManager_EFCore.Data;
using Datalagring_ProjectManager_EFCore.Models;
using Microsoft.Extensions.Logging;
using static System.Console;

namespace Datalagring_ProjectManager_EFCore
{
    class Program
    {
        //static ILoggerFactory MyLoggerFactory = LoggerFactory.Create(DbContextOptionsBuilder => DbContextOptionsBuilder.AddConsole());
        //static ProjectManagerContext context = new ProjectManagerContext(MyLoggerFactory);

        static ProjectManagerContext Context = new ProjectManagerContext();

        static void Main(string[] args)
        {
            bool shouldNotExit = true;

            while (shouldNotExit)
            {
                WriteLine("");
                WriteLine("1. Add employee");
                WriteLine("2. List employees");
                WriteLine("3. Utför besiktning");
                WriteLine("4. Lista besiktningar");
                WriteLine("5. Avsluta");

                ConsoleKeyInfo keyPressed = ReadKey(true);
                Clear();
                switch (keyPressed.Key)
                {
                    // New employee
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        AddEmployee();
                        break;
                    // List employees
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        //ListaEmployees();
                        ReadKey(true);
                        break;
                    //// Utför besiktning
                    //case ConsoleKey.D3:
                    //case ConsoleKey.NumPad3:
                    //    UtförBesiktning();
                    //    break;
                    //case ConsoleKey.D4:
                    //case ConsoleKey.NumPad4:
                    //    ListaBesiktningar();
                    //    ReadKey(true);
                    //    break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        shouldNotExit = true;
                        break;
                }

                Clear();
            }

        }

        private static void AddEmployee()
        {
            Write("First name: ");
            string firstName = ReadLine();

            Write("Last name: ");
            string lastName = ReadLine();

            Write("Social security number: ");
            string socialSecurityNumber = ReadLine();            

            Write("Clearing nr: ");
            string clearingNumber = ReadLine();

            Write("Account nr: ");
            string accountNumber = ReadLine();

            Write("Bank: ");
            string bank = ReadLine();

            Account paymentAccount = new Account(clearingNumber ,accountNumber, bank);

            Employee employee = new Employee(firstName, lastName, socialSecurityNumber, paymentAccount);
            SaveEmployee(employee);

            Clear();

            WriteLine("Employee added");

            Thread.Sleep(2000);

        }

        private static void SaveEmployee(Employee employee)
        {
            if (employee.Id < 1)
            {
                Context.Employees.Add(employee);
            }

            Context.SaveChanges();
        }
        private static void ListEmployees()
        {
            using (var context = new ProjectManagerContext())
            {
                var employees = context.Employees.ToList();
                if (employees.Count == 0)
                {
                    WriteLine("No employees found.");
                }
                else
                {
                    foreach (var employee in employees)
                    {
                        WriteLine($"ID: {employee.Id}, Name: {employee.FirstName} {employee.LastName}, SSN: {employee.SocialSecurityNumber}");
                    }
                }
            }
            WriteLine("Press any key to continue...");
            ReadKey(true);
        }
    }
}
