using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance;

internal class ChildClass2 : BaseClass
{
    public bool ChildMethode2()
    {
        Console.WriteLine("ChildMethode2" + base.BaseStr);

        base.BaseMethod();

        return true;
    }
}
