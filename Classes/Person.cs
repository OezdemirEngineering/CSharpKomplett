using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes;

internal class Person
{
    //Properties
    public string FirstName; 
    public string LastName;
    public int Age;
    public string Email 
    {
        get
        {
            return _email;
        }
        set
        {
            if (value.Contains("@"))
            {
                _email = value;
            }
        }
    }

    //Fields
    private string _email;

}
