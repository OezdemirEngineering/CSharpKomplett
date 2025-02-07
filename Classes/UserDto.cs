using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes;

internal record UserDto(string FirstName, string LastName, int Age, string Email)
{
}
