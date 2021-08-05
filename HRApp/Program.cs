using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLib;

namespace HRApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string reRun = "N";
            string choice = "0";
            Dictionary<string, Employee> employees = new Dictionary<string, Employee>();
            do
            {
                Console.WriteLine("1 Display All Employees " +
                    "\n2 Insert Confirm Employee " +
                    "\n3 Insert Trainee Employee " +
                    "\n4 Remove Employee by Name " +
                    "\n5 Display Employee by Name " +
                    "\n6 Exit");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        foreach (var entry in employees)
                        {
                            Console.WriteLine(entry.Value.ToString());
                            Console.WriteLine("Net Salary = " + entry.Value.CalculateSalary());
                        }
                        break;
                    case "2":
                        try
                        {
                            Console.WriteLine("Enter Name");
                            string confirmName = Console.ReadLine();
                            Console.WriteLine("Enter Address");
                            string confirmAddress = Console.ReadLine();
                            Console.WriteLine("Enter Designation");
                            string confirmDesignation = Console.ReadLine();
                            Console.WriteLine("Enter Basic > 5000");
                            double confirmBasic = Convert.ToDouble(Console.ReadLine());
                            ConfirmEmployee confirmEmployee = new ConfirmEmployee(confirmName, confirmAddress, confirmBasic, confirmDesignation);
                            employees.Add(confirmName, confirmEmployee);
                        }
                        catch (MinimumBasicException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter Name");
                        string traineeName = Console.ReadLine();
                        Console.WriteLine("Enter Address");
                        string traineeAddress = Console.ReadLine();
                        Console.WriteLine("Enter Number of Days");
                        int traineeNumberOfDays = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Rate");
                        double traineeRate = Convert.ToDouble(Console.ReadLine());
                        Trainee traineeEmployee = new Trainee(traineeName, traineeAddress, traineeNumberOfDays, traineeRate);
                        employees.Add(traineeName, traineeEmployee);
                        break;
                    case "4":
                        Console.WriteLine("Enter name to remove:");
                        string nameToRemove = Console.ReadLine();
                        if (employees.Remove(nameToRemove))
                        {
                            Console.WriteLine($"Succesfully Removed {nameToRemove}");
                        }
                        else
                        {
                            Console.WriteLine($"{nameToRemove} was not removed");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Enter name to display");
                        string nameToDisplay = Console.ReadLine();
                        if (employees.ContainsKey(nameToDisplay))
                        {
                            Console.WriteLine(employees[nameToDisplay].ToString());
                        }
                        else
                        {
                            Console.WriteLine($"Employee {nameToDisplay} does not exist");
                        }
                        break;
                    case "6": return;

                }
                Console.WriteLine("Do you want to continue (Y/N)");
                reRun = Console.ReadLine();

            } while (reRun == "Y");
        }
    }
}
