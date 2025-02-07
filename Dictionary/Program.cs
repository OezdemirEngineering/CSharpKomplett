namespace Dictionary;

public class Program
{
    static void Main()
    {
        Dictionary<int,string> persons = new Dictionary<int, string>();

        persons.Add(1, "Hans");
        persons.Add(2, "Peter");
        persons.Add(3, "Klaus");

        var person = persons[3];


        // Error Message Mapper 
        Dictionary<int, string> errorMessages = new Dictionary<int, string>()
        {
            { 404, "Not Found" },
            { 500, "Internal Server Error" },
            { 401, "Unauthorized" }
        };


        // Gets null if not available
        errorMessages.TryGetValue(400, out string message);

    }
}