using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance;

internal class ChildClass : BaseClass
{
    public void ChildMethode()
    {
        Console.WriteLine("ChildMethode" + base.BaseStr);

        base.BaseMethod();
    }
}
