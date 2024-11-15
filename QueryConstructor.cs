﻿// QueryConstructor.cs

using SecurityAssignmentFiveCit.Login;
using System.Xml.Linq;
public class QueryConstructor
{
    public LoginCredentials login;
    public PostgreSQL_Client securelogin;
    public QueryConstructor()
    {
        client   = new PostgreSQL_Client("university", "postgres", LoginCredentials.filecontent);
        // retain university database
        // but change username and password
        

    }
    

    public PostgreSQL_Client client;
    public PostgreSQL_Client secureClient;

    // method definitions

    // dynamicQuery()
    // Get user-defined query, send query to db

    public void dynamicQuery()
    {
        // defining the query 
        Console.Write("Please type any SQL query: ");
        string? sql = Console.ReadLine();

        // printing query string to console
        Console.Write("Query to be executed: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(sql + "\n");
        Console.ForegroundColor = ConsoleColor.Black;

        // executing query
        client.query(sql);
    } // end method dynamicQuery() 

    // composedQuery()
    // Get dynamic part from user,
    // then compose dynamic and static part,
    // and send query to db

    virtual public void composedQuery()
    {
        // defining the query
        string staticSQLbefore = "select * from course where course_id = '";
        Console.Write("Please type id of a course: ");
        string? user_defined = Console.ReadLine();
        string staticSQLafter = "' and dept_name != 'Biology'";
        string sql = staticSQLbefore + user_defined + staticSQLafter;

        // printing query string to console
        Console.Write("Query to be executed: " + staticSQLbefore);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(user_defined);
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine(staticSQLafter + "\n");

        // executing query
        client.query(sql);
    }

    virtual public void safeComposedQuery()
    {
        string illegalCharacter1 = "\'"; 
        string illegalCharacter2 = "\"";
        string illegalCharacter3 = "\";";
        string illegalCharacter4 = "\\";
        string illegalCharacter5 = "--";


        //Securíty for the win, get fuck you, you cannot get in!!!
        //Attempt at using query /3
        Console.WriteLine("Please input your username: ");
        string? name = Console.ReadLine();
        Console.WriteLine("Please input your password: ");
        string? password = Console.ReadLine();
        if (IsValidUser(name, password))
        {
            string? secureSql = "select * from safe_course(@courseId)";


            Console.Write("Please type the ID of a course");
            string? courseId = Console.ReadLine();
            secureClient = new PostgreSQL_Client(secureSql, @courseId, courseId);
            Console.WriteLine("Executing secures SQL query with parameterized input");
            
            //defining the query
            string staticSQLbefore = "select * from safe_course('";
            Console.Write("Please type id of a course: ");
            string? user_defined = Console.ReadLine();
            string staticSQLafter = "')";
            string sql = staticSQLbefore + user_defined + staticSQLafter;
            

            //printing query to console
            Console.Write("Query to be executed: " + staticSQLbefore);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(user_defined);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(staticSQLafter + "\n");

            //executing query
            secureClient.query(secureSql, "@courseId", courseId);
        }
        else
        {
            Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("Invalid username or password");
            Console.ForegroundColor = ConsoleColor.Black;
        }

    }
    private bool IsValidUser(string? name, string? password)
    {
        return name == "expectedUsername" && password == "expectedPassword";
    }
}
