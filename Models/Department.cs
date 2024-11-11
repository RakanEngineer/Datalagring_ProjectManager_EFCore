using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalagring_ProjectManager_EFCore.Models
{
    class Department
    {
        public Department(string name) 
        { 
            Name = name;
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public List<Employee> Employees { get; protected set; } = new List<Employee>();

    }
}
