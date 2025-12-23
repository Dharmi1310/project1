using MySql.Data.MySqlClient;
//using MyWebApp.Controllers;
namespace empp.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public int salary { get; set; }
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
            ViewAll();
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
            ViewAll();
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
                        Console.WriteLine("---------------------------------------");
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["id"]}\t{reader["name"]}\t{reader["department"]}\t\t{reader["salary"]}");

                            Console.WriteLine("---------------------------------------");
                        }
                    }
                }
            }
        }
    }
    public class SearchExample
    {
        public void LinearSearch()
        {
            int[] arr = new int[5];
            for (int i = 0; i < 5; i++)
            {

                Console.WriteLine("enter a " + i + " element");
                arr[i] = Convert.ToInt32(Console.ReadLine());

            }
            Console.WriteLine("enter the target value");
            int t = Convert.ToInt32(Console.ReadLine());
            bool Value = true;
            for (int j = 0; j < 5; j++)
            {

                if (arr[j] == t)
                {

                    Console.WriteLine("Element found in  " + j);
                    Value = false;
                    break;

                }
            }
            if (Value == true)
            {
                Console.WriteLine("Element Not Found");
            }
        }
        public void BinarySearch()
        {
            int[] arr = new int[5];
            for (int m = 0; m < 5; m++)
            {
                Console.WriteLine("enter a " + m + " element");
                arr[m] = Convert.ToInt32(Console.ReadLine());
            }
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
    public class RomanToDecimal
    {
        public int RomanValue(char c)
        {
            switch (c)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default: return 0;
            }
        }

        public void Roman()
        {
            Console.Write("Enter Roman Number: ");
            string roman = Console.ReadLine().ToUpper();

            int total = 0;

            for (int i = 0; i < roman.Length; i++)
            {
                int current = RomanValue(roman[i]);

                if (i + 1 < roman.Length && current < RomanValue(roman[i + 1]))
                    total -= current;
                else
                    total += current;
            }

            Console.WriteLine("Decimal Value: " + total);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            UserMainCode usm = new UserMainCode();
            int[] arr = {5,5,5,5,5};
            //usm.findResult(5,arr);
            EmployeeManagement em = new EmployeeManagement();
            StudentMAnagement stm = new StudentMAnagement();
            SearchExample example = new SearchExample();
           // example.LinearSearch();
            RomanToDecimal r1 = new RomanToDecimal();
            //r1.Roman();
            while (true)
            {
                Console.WriteLine("Enter 1 for Employee Details");
                Console.WriteLine("Enter 2 for Student Details");
                Console.WriteLine("Enter 3 for exit");
                int mainchoice = int.Parse(Console.ReadLine());

                switch (mainchoice)
                {
                    case 1:
                        bool ex = true;
                        while (ex)
                        {
                            Console.WriteLine("\n1. Add Employee");
                            Console.WriteLine("2. Delete Employee");
                            Console.WriteLine("3. View All Employees");
                            Console.WriteLine("4. Binary Search Example");
                            Console.WriteLine("5. Linear Search Example");
                            Console.WriteLine("6. Exit");
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
                                    SearchExample s1 = new SearchExample();
                                    s1.BinarySearch();
                                    break;
                                case 5:
                                    sorting s2 = new sorting();
                                    s2.bublesort();
                                    break;
                                case 6:
                                    ex = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice, try again!");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        bool n = true;
                        while (n)
                        {
                            Console.WriteLine("\n1. Add student");
                            Console.WriteLine("2. Delete Student");
                            Console.WriteLine("3. View all Student Details");
                            Console.WriteLine("4. exit");
                            int choise2 = int.Parse(Console.ReadLine());

                            switch (choise2)
                            {
                                case 1:
                                    stm.Addstu();
                                    break;

                                case 2:
                                    stm.Delete();
                                    break;
                                case 3:
                                    stm.viewal();
                                    break;
                                case 4:
                                    n = false;
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice , try again");
                                    break;
                            }
                        }
                        break;
                    case 3:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice, try again");
                        break;

                }

            }
        }
    }
}
