using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes;

// primary constructor 
internal class UserService(List<PersonDto> users)
{
    public List<PersonDto> Users
    {
        set => _users =value;
        get => _users;
    }

    public List<PersonDto> Users2
    {
        set
        {
            _users = value;
        }
        get
        {
          return  _users;
        }
    }


    List<PersonDto> _users;

    public List<PersonDto> GetUsers()
    {

        // Count is a property of the List class which is get only 
        //var count = Users.Count;
        return users;
    }

}
