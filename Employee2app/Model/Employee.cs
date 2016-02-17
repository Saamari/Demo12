using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee2app.Model
{
    public class Employee
    {
        public string ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string JobTitle { get; set; }
        public EmployeeImage Image { get; set; }
        public string Fullname
        {
            get
            {
                return Lastname + " " + Firstname;
            }
        }
    }

    /// <summary>
    /// This class holds employee view model data.
    /// </summary>
    public class EmployeeViewModel
    {
        //  private List<Employee> employees = new List<Employee>();
        //public List<Employee> Employees { get { return employees; } }
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> Employees { get { return employees; } }

        //Constructor
        public EmployeeViewModel()
        {
            // generate dummy data if needed
        }

        //metodi lisää uuden employeen kokoelmaan
        public void AddEmployee(string firstname, string lastname, string jobTitle,EmployeeImage image)
        {
            //luodaan uusi employee
            string id = "0001";//kaikilla sma ID.....random?
            employees.Add(new Employee { ID = id, Firstname = firstname, Lastname = lastname, JobTitle = jobTitle, Image = image });
        }
    }
}
    
