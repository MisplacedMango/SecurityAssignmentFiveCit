// Program.cs
// Entry point of the application SQL Injection Frontend

// Program.cs defines a simple 'looping' interface
// that asks the end user for input.
// In response to user input,
// the program calls an instance of class QueryConstructor

// Welcome message
Console.WriteLine("Welcome to the password-based authenticator");
Console.WriteLine("");

Authenticator auth = new Authenticator();

Console.WriteLine("Registering user admin");
auth.register("admin", "admindnc");

Console.WriteLine("Welcome to SQL Injection Frontend\n");

QueryConstructor qConstructor = new QueryConstructor();
// QueryConstructor qConstructor = new QueryConstructorSolution();
// class QueryConstructorSolution contains assignment solutions
// and is not provided on moodle

// the user interface
string? s = "x";
do
{
    Console.Write("Please select character + enter\n"
            + "'r' (register)\n"
            + "'l' (login)\n"
            + "'x' (exit)\n"
            + ">");
    s = Console.ReadLine();
    Console.WriteLine();
    switch (s)
    {
        case "r":
            register(auth);
            break;
        case "l":
            login(auth);
            break;
        case "x":
            Console.WriteLine("exiting ..");
            break;
        default:
            Console.WriteLine("you typed " + "'" + s + "'" + " -- use a suggested value");
            break;
    } // end switch

do
{
    
    Console.Write("Please select character + enter\n"
            + "'d' (dynamic query)\n"
            + "'c' (composed query)\n"
            + "'sc' (safe composed query)\n"
            + "'x' (exit)\n"
            + ">");
    s = Console.ReadLine();
    Console.WriteLine();
    switch (s)
    {
        case "d":
            qConstructor.dynamicQuery();
            break;
        case "c":
            qConstructor.composedQuery();
            break;
        case "sc":
            qConstructor.safeComposedQuery();
            break;
        case "x":
            Console.WriteLine("exiting ..");
            break;
        default:
            Console.WriteLine("you typed " + "'" + s + "'" + " -- please use a suggested value");
            break;
    } // end switch
} while (s != "x");

} while (s != "x");

void register(Authenticator auth)
{
    Console.WriteLine("Registration .. ");
    string username = getUserInput("Please type username:");
    string password = getUserInput("Please type password:");
    bool registered = auth.register(username, password);
    if (registered) Console.WriteLine("Registration succeeded");
    else Console.WriteLine("Registration failed");
}

void login(Authenticator auth)
{
    Console.WriteLine("Logging in .. ");
    string username = getUserInput("Please type username:");
    string password = getUserInput("Please type password:");
    bool loggedin = auth.login(username, password);
    if (loggedin) Console.WriteLine("Login succeeded");
    else Console.WriteLine("Login failed");
}

// helper functions for exit(), register() and login()

string getUserInput(string s)
{
    Console.WriteLine(s);
    return Console.ReadLine() ?? readLineError();
}

string readLineError()
{
    return "Error: no string read by Console.ReadLine()";
}


