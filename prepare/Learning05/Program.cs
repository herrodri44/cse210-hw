using System;

class Program
{
    static void Main(string[] args)
    {
        Square mySquare = new Square("red", 4);
        Rectangle myRectangle = new Rectangle("red", 8, 3);
        Circle myCircle = new Circle("red", 2);

        List<Shape> shapeList = new List<Shape>();
        shapeList.Add(mySquare);
        shapeList.Add(myRectangle);
        shapeList.Add(myCircle);
        
        foreach (Shape s in shapeList)
        {
            double area = s.GetArea();
            Console.WriteLine($"Shape area: {area}");
        }
    }
}