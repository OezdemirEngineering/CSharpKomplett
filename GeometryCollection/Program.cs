using GeometryCollection;

namespace GeoemtryCollection;

public class Program
{
    static void Main()
    {
        var rectangle = new RectangleGeometry(10, 20);
        var circle = new CircleGeometry(10);

        var path = new PathGeometry([rectangle,circle]);


        new CalculationService(path).ProcessCalculations();
    }



}