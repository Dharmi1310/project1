using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MyWebApp.Controllers;
using System;
using System.Collections.Generic;

namespace empp.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public int salary { get; set; }
    }
    public interface Pay
    {
       public void card_payment();
        public void cash_payment();
    }
    public class payment : Pay
    {
       public  void card_payment()
        {
            Console.WriteLine("payment through the card");
        }
        public void cash_payment()
        {
            Console.WriteLine("Paymrnt through the cash");
        }
    }
    public class EmployeeManagement
    {
        private string connectsql = "Server=localhost;user id=root;password=1122;database=Employeedb;";

        // Add employee to database
        public void Add()
        {
            Employee emp = new Employee();

            Console.WriteLine("Enter employee id = ");
            emp.id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter employee name = ");
            emp.name = Console.ReadLine();

            Console.WriteLine("Enter department name = ");
            emp.department = Console.ReadLine();

            Console.WriteLine("Enter salary = ");
            emp.salary = int.Parse(Console.ReadLine());

            using (MySqlConnection conn = new MySqlConnection(connectsql))
            {
                conn.Open();
                string query = "INSERT INTO Employee (id, name, department, salary) VALUES (@id, @name, @department, @salary)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", emp.id);
                    cmd.Parameters.AddWithValue("@name", emp.name);
                    cmd.Parameters.AddWithValue("@department", emp.department);
                    cmd.Parameters.AddWithValue("@salary", emp.salary);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Employee added successfully!");
                    }
                    catch (MySqlException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }

        // Delete employee by id
        public void Delete()
        {
            Console.WriteLine("Enter employee id to delete: ");
            int id = int.Parse(Console.ReadLine());

            using (MySqlConnection conn = new MySqlConnection(connectsql))
            {
                conn.Open();
                string query = "DELETE FROM Employee WHERE id=@id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                        Console.WriteLine("Employee deleted successfully!");
                    else
                        Console.WriteLine("Id not found in database.");
                }
            }
        }
        // View all employees
        public void ViewAll()
        {
            using (MySqlConnection conn = new MySqlConnection(connectsql))
            {
                conn.Open();
                string query = "SELECT * FROM Employee";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("ID\tName\tDepartment\tSalary");
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["id"]}\t{reader["name"]}\t{reader["department"]}\t{reader["salary"]}");
                        }
                    }
                }
            }
        }
    }

    public class BinarySearchExample
    {
        public void Search()
        {
            int[] arr = { 1, 2, 4, 7, 8 };
            int start = 0, end = arr.Length - 1;

            Console.WriteLine("Enter target: ");
            int target = int.Parse(Console.ReadLine());

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (arr[mid] == target)
                {
                    Console.WriteLine("Element found at position " + (mid + 1));
                    return;
                }
                else if (target < arr[mid])
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            Console.WriteLine("Element not found");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            payment paym = new payment();
            paym.card_payment();
            paym.cash_payment();
            ProductsController cb = new ProductsController();
            cb.GetAll();
            EmployeeManagement em = new EmployeeManagement();

            while (true)
            {
                Console.WriteLine("\n1. Add Employee");
                Console.WriteLine("2. Delete Employee");
                Console.WriteLine("3. View All Employees");
                Console.WriteLine("4. Binary Search Example");
                Console.WriteLine("5. Exit");

                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        em.Add();
                        break;
                    case 2:
                        em.Delete();
                        break;
                    case 3:
                        em.ViewAll();
                        break;
                    case 4:
                        BinarySearchExample bse = new BinarySearchExample();
                        bse.Search();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, try again!");
                        break;
                }
            }
        }
    }
}
