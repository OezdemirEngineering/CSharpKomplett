using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes;

internal class DbService : IDisposable
{

    public DbService(string address , string username, string password)
    {
        // built db connection 
    }

    public void Dispose()
    {
        // is calles when object is disposed
        // like a destructor 
        // close db connection
        // 
    }
}
