using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework9
{
    internal class Company
    {
        double fullPay { get; set; }
        double taxPay { get; set; }
        double employeePay {  get; set; }
        bool isLocal;

        private List<Employee> employees = new List<Employee>();
        public Company(bool isLocal)
        {
            this.isLocal = isLocal;
        }
         public void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                return;
            }
            else
            {
                employees.Add(employee);
                fullPay += employee.Salary();
            }
        }
        public double CalculateTax()
        {
            if (isLocal) 
            {
                taxPay = fullPay * 0.18;
            }
            else
            {
                taxPay = fullPay * 0.05;
            }

            return taxPay;
        
        }
    }
}
