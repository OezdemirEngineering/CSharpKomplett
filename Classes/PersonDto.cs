using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes;

internal class PersonDto
{

    public PersonDto(string firstName, string lastName, int age, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        _age = age;
        Email = email;
    }

    /// <summary
    /// init means that the property can only be set in the constructor
    /// </summary>
    public string FirstName { init; get; }
    public string LastName { get; set; }
    public int Age => _age;
    public string Email { get; set; }

    private int _age;
}
