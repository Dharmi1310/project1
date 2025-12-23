using MySql.Data.MySqlClient;
using System.Reflection.PortableExecutable;
public class Student
{
    public int Student_Id { get; set; }
    public string Student_Name { get; set; }
    public int Student_Class { get; set; }
}
public class StudentMAnagement
{
    private string location = "Server=localhost;user id=root;password=1122;database=Employeedb";
    public void Addstu()
    {
        Student st = new Student();

        Console.WriteLine("enter student id");
        st.Student_Id =int.Parse(Console.ReadLine());

        Console.WriteLine("enter student name");
        st.Student_Name = Console.ReadLine();

        Console.WriteLine("enter student Class");
        st.Student_Class = int.Parse(Console.ReadLine());

        MySqlConnection con = new MySqlConnection(location);
        con.Open();

        string query = "insert into student(Student_Id,Student_Name,Student_Class) values(@Student_Id,@Student_Name,@Student_Class)";

        using(MySqlCommand cmd=new MySqlCommand(query, con)) 
        {

            cmd.Parameters.AddWithValue("@Student_Id", st.Student_Id);
            cmd.Parameters.AddWithValue("@Student_Name", st.Student_Name);
            cmd.Parameters.AddWithValue("@Student_Class", st.Student_Class);

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
        viewal();
    }
    public void Delete()
    {
        Console.WriteLine("enter the student id");
        int Student_Id = int.Parse(Console.ReadLine());

        using (MySqlConnection con=new MySqlConnection(location))
        {
            con.Open();
            string query = "delete from student where Student_Id=@Student_Id";
            using (MySqlCommand cmd=new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@Student_Id",Student_Id);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    Console.WriteLine("Employee deleted successfully!");
                else
                    Console.WriteLine("Id not found in database.");
            }
        }
    }
    public void viewal()
    {
        using(MySqlConnection con=new MySqlConnection(location))
        {
            con.Open();
            string query = "select * from student";
            using(MySqlCommand cmd =new MySqlCommand(query , con))
            {
                using(MySqlDataReader reader= cmd.ExecuteReader())
                {
                    Console.WriteLine("Student_Id\t Student_Name\t Student_Class");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Student_Id"]}\t\t{reader["Student_Name"]}\t\t{reader["Student_Class"]}");
                    }
                }
            }
        }
    }
}