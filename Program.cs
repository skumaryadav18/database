using System;
using System.Data.SqlClient;

public class EmployeeDatabase
{
    
    public SqlConnection GetConnection()
    {
        SqlConnection con = new SqlConnection("data source = .; database = EmployeDb; User Id = ranadheer; Password = ravan2451");
        return con;
    }
    public void CreateEmployeeTable()
    {
   
        SqlConnection con = GetConnection();
        string sql = "create table employee(id int primary key, name varchar(20) not null, sal money not null)";
        con.Open();
        SqlCommand cmd = new SqlCommand(sql, con);
        int result = cmd.ExecuteNonQuery();
        Console.WriteLine(result + " table created");
        con.Close();
    }

    //Inserting data into table
    public void InsertEmployeeData(int eid, string ename, double esal)
    {
        //Getting connection from database
        SqlConnection con = GetConnection();

        //creation of insertion query
        string query = "insert into employee values(@id, @name, @sal)";
        con.Open();
        SqlCommand cmd = new SqlCommand(query, con);

        //Assigning a value to the parameters
        cmd.Parameters.AddWithValue("@id", eid);
        cmd.Parameters.AddWithValue("@name", ename);
        cmd.Parameters.AddWithValue("@sal", esal);

        //Execution of non select query
        int recordsInserted = cmd.ExecuteNonQuery();
        Console.WriteLine(recordsInserted + " record inserted");
        con.Close();
    }

    public void GetEmployeeData()
    {
        //Getting connection from database
        SqlConnection con = GetConnection();

        //creation of select query
        string query = "select * from employee";

        SqlCommand cmd = new SqlCommand(query, con);
        con.Open();

        //Executing a select query
        SqlDataReader reader = cmd.ExecuteReader();

        //Retrieving results using while loop
        while (reader.Read())
        {
            Console.WriteLine("Id : " + reader["id"] + " " + " Name : " + reader["name"] + " " + "Salary : " + reader["sal"]);
        }
        con.Close();
    }

    public static void Main(string[] args)
    {
        //Object creation
        EmployeeDatabase empDb = new EmployeeDatabase();

        //calling create table method
        empDb.CreateEmployeeTable();

        //calling insert employee data method
        empDb.InsertEmployeeData(1, "Ranjith", 70000.0);
        empDb.InsertEmployeeData(2, "Rahul", 65000.0);
        empDb.InsertEmployeeData(3, "Rohith", 60000.0);

        //Retrieving records
        empDb.GetEmployeeData();
        Console.ReadLine();
    }
}