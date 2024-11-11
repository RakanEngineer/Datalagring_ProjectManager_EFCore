using Datalagring_ProjectManager_EFCore.Data;
using Datalagring_ProjectManager_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static System.Console;

namespace Datalagring_ProjectManager_EFCore
{
    class Program
    {
        //static ILoggerFactory MyLoggerFactory = LoggerFactory.Create(DbContextOptionsBuilder => DbContextOptionsBuilder.AddConsole());
        //static ProjectManagerContext context = new ProjectManagerContext(MyLoggerFactory);

        static ProjectManagerContext context = new ProjectManagerContext();

        static void Main(string[] args)
        {
            bool shouldNotExit = true;

            while (shouldNotExit)
            {
                WriteLine("");
                WriteLine("1. Add employee");
                WriteLine("2. List employees");
                WriteLine("3. Add department");
                WriteLine("4. List department");
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
                        ListEmployees();
                        ReadKey(true);
                        break;
                    // Add department
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        AddDepartment();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        
                        ReadKey(true);
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        shouldNotExit = true;
                        break;
                }

                Clear();
            }

        }

        private static void AddDepartment()
        {
            Write("Name: ");
            string name = ReadLine();
            Department department = new Department(name);
            SaveDepartment(department);
            Clear();
            WriteLine("Department added");
            Thread.Sleep(2000);
        }

        private static void SaveDepartment(Department department)
        {
            //context.Department.Add(department); 
            //context.SaveChanges();
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

            //Write("Department: ");
            //string departmentName = ReadLine();
            //Department department = context.Department.FirstOrDefault(x => x.Name == departmentName);
            //if (department != null)
            {
                Account paymentAccount = new Account(clearingNumber, accountNumber, bank);

                Employee employee = new Employee(firstName, lastName, socialSecurityNumber, paymentAccount);
                SaveEmployee(employee);

                Clear();

                WriteLine("Employee added");
            }
            //else
            //{
            //    WriteLine("Department not found");
            //}

            

            Thread.Sleep(2000);

        }

        private static void SaveEmployee(Employee employee)
        {
            if (employee.Id < 1)
            {
                context.Employees.Add(employee);
            }

            context.SaveChanges();
        }
        private static void ListEmployees()
        {
            using (var context = new ProjectManagerContext())
            {
                var employees = context.Employees.Include(x=> x.PaymentAccount).ToList();

                Write("Namn".PadRight(20, ' '));
                WriteLine("Account nummer");
                WriteLine("------------------------------------------------");
                if (employees.Count == 0)
                {
                    WriteLine("No employees found.");
                }
                else
                {
                    foreach (var employee in employees)
                    {
                        WriteLine($"{employee.FirstName} {employee.LastName},{employee.SocialSecurityNumber}, {employee.PaymentAccount.ClearingNumber}");
                    }
                }
            }
            WriteLine("Press any key to continue...");
            ReadKey(true);
        }
    }
}
