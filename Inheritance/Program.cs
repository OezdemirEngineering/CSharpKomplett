namespace Inheritance;


public class Program
{
    static void Main()
    {
        // parent class
        var baseClasse = new BaseClass();
        baseClasse.BaseMethod();

        // child class which inheritates from parent class
        var childClass = new ChildClass();
        childClass.ChildMethode();
        childClass.BaseMethod();

        // child class which inheritates from parent class
        var childClass2 = new ChildClass2();
        childClass2.ChildMethode2();
        childClass2.BaseMethod();

        List<BaseClass> classes = [baseClasse, childClass, childClass2];

        foreach (var item in classes)
        {
            if( item  is ChildClass)
            {
                (item as ChildClass).ChildMethode();
            }

            if (item is ChildClass2)
            {
                (item as ChildClass2).ChildMethode2();
            }
        }


        // filterest all types with contains ChildClass and access the first element of the 
        // filtered collection 
        classes.OfType<ChildClass2>().ToList()[0].ChildMethode2();


        // filteres all types which contains the type <see ref="ChildClass2"/>  and adds the results to a list 
        var list = classes.OfType<ChildClass2>().Select(x =>x.ChildMethode2());


        // interates through the list with foreach 
        classes.OfType<ChildClass>().ToList().ForEach(x => x.ChildMethode());

        classes.OfType<ChildClass>().ToList().ForEach(x => 
        {
            x.ChildMethode();
        });


    }
}