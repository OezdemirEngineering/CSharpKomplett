
using CrmService;

namespace Classes
{


    public class Program
    {
        static void Main()
        {
            Person person = new Person();

            person.FirstName = "Hans";
            person.LastName = "Muster";
            person.Age = 30;

            var mail = person.Email;

            person.Email = "mail";
            person.Email = "info@oeeng.de";


            // var deklaration
            var person2 = new Person();

            // Object initialization
            Person person3 = new();


            // Object initialization with values
            Person person4 = new()
            {
                FirstName = "Hans",
                LastName = "Muster",
                Age = 30
            };

            // Static class , no instance needed
            var distance = DistanceCalculaterUtil.CalculateDistance(10, 7.5);

            // Object initialization with values, by using a constructor
            var personDto = new PersonDto(mail, person.LastName, person.Age, person.Email);

            // Object initialization with values, by using a constructor
            // dispose is automatically calles after this method is return
            // when application is closed
            using (var dbService = new DbService("localhost", "root", "password"))
            {
                // dispose is calles when this scope is left 

            }

            // Object initialization with values, by using a constructor
            var userService = new UserService(new List<PersonDto> { personDto });


            // the third element exits only inside the passed instanz of userService
            userService = new UserService(
                [personDto, 
                personDto, 
                new PersonDto(mail, person.LastName, person.Age, person.Email)]);

            var users = userService.GetUsers();

            var users2 = new UserService([personDto,personDto]).GetUsers();

            // initialize a record
            var userDto = new UserDto("Hans", "Muster", 30, "");

            // init only 
            var mail2 = userDto.Email;



            // 
            var personalDto = new PersonalDto("Hans", "Muster", 30, "");
            var productDto = new ProductDto("Kaffee","5 euro");
            var orderDto = new OrderDto("001", [productDto]);
            var userDtoCrm = new CrmService.UserDto(personalDto,[orderDto]);
            var crmService = new Service([userDtoCrm]);

            var orders = crmService.GetAllOrders();


        }
    }
}