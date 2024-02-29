using System;

class Program
{
    
    static void Main()
    {
        string lineEquation = LineEquation(1, 1, 1, 1);
        Console.WriteLine(lineEquation);
        Console.WriteLine();
        string pointBelong = PointBelong(0, 0, 2, 2, 0.15, 0.15);
        Console.WriteLine(pointBelong);
        Console.WriteLine();
        string straightAngle = AngleType(1, 1, 0, 0, 0.5, -0.5);
        string acuteAngle = AngleType(1, 1, 0, 0, 1, 0);
        string obtuseAngle = AngleType(1, 1, 0, 0, 0, -1);
        string nonExistentAngle = AngleType(1, 0, 2, 0, 3, 0);
        Console.WriteLine(straightAngle);
        Console.WriteLine();
        Console.WriteLine(acuteAngle);
        Console.WriteLine();
        Console.WriteLine(obtuseAngle);
        Console.WriteLine();
        Console.WriteLine(nonExistentAngle);
        Console.WriteLine();
        string planeEquation = PlaneEquation(1, 1, 1, 2, 2, 2, 3, 3, 3);
        Console.WriteLine(planeEquation);
        Console.WriteLine();
        List<Tuple<double, double>> intersectionPoints = CirlceIntersection(2, 2, 5, -1, -2, 8);
        foreach (var point in intersectionPoints)
        {
            int i = 1;
            Console.WriteLine($"P{i}(" + point.Item1 + "," + point.Item2 + ")");
            i++;
        }
        Console.WriteLine();
        List<Tuple<double, double>> intersectionPoint = CirlceIntersection(0, 0, 1, 2, 0, 1); // Одна точка
        foreach (var point in intersectionPoint)
        {
            int i = 1;
            Console.WriteLine($"P{i}(" + point.Item1 + "," + point.Item2 + ")");
            i++;
        }
        Console.WriteLine();
        List<Tuple<double, double>> nonIntersection = CirlceIntersection(0, 0, 8, 0, 0, 5); // точек пересечения нет, в список пустой
        foreach (var point in nonIntersection)
        {
            int i = 1;
            Console.WriteLine($"P{i}(" + point.Item1 + "," + point.Item2 + ")");
            i++;
        }
        Console.WriteLine(nonIntersection.Count());

        List<Tuple<double, double>> intersectionPoint1 = CirlceIntersection(0, 0, 5, 0, 0, 5);
        foreach (var point in intersectionPoint1)
        {
            int i = 1;
            Console.WriteLine($"P{i}(" + point.Item1 + "," + point.Item2 + ")");
            i++;
        }
        Console.WriteLine("#1 count " + intersectionPoint1.Count());
        Console.WriteLine();
        List<Tuple<double, double>> intersectionPoint2 = CirlceIntersection(0, 0, 5, 0, 3, 2);
        foreach (var point in intersectionPoint2)
        {
            int i = 1;
            Console.WriteLine($"P{i}(" + point.Item1 + "," + point.Item2 + ")");
            i++;
        }
        Console.WriteLine("#2 count " + intersectionPoint2.Count());
        Console.WriteLine();
        List<Tuple<double, double>> intersectionPoint3 = CirlceIntersection(0, 0, 5, 10, 0, 5);
        foreach (var point in intersectionPoint3)
        {
            int i = 1;
            Console.WriteLine($"P{i}(" + point.Item1 + "," + point.Item2 + ")");
            i++;
        }
        Console.WriteLine("#3 count " + intersectionPoint3.Count());
        Console.WriteLine();
        List<Tuple<double, double>> intersectionPoint4 = CirlceIntersection(0, 0, 5, 10, 8, 10);
        foreach (var point in intersectionPoint4)
        {
            int i = 1;
            Console.WriteLine($"P{i}(" + point.Item1 + "," + point.Item2 + ")");
            i++;
        }
        Console.WriteLine("#4  count" + intersectionPoint4.Count());
        Console.WriteLine();

    }

    static string LineEquation(double x1, double y1, double x2, double y2) // Задание 1
    {
        double coefX = y2 - y1;
        double coefY = -(x2 - x1);
        if (Math.Abs(x1 - x2) < Double.Epsilon && Math.Abs(y1 - y2) < Double.Epsilon)
        {
            coefX = 1;
            coefY = 1;
        }
        double freeTerm = -x1 * (coefX) + y1 * -(coefY);
        string signY = coefY >= 0 ? "+" : "-";
        string signFreeTerm = freeTerm >= 0 ? "+" : "-";     
        return string.Format($"Общее уравнение прямой, заданной точками A({x1:F8};{y1:F8}), B({x2:F8};{y2:F8}):\n{coefX:F8}x {signY} {Math.Abs(coefY):F8}y {signFreeTerm} {Math.Abs(freeTerm):F8} = 0");
    }

    static double SegmentLength(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }
    static string PointBelong(double x1, double y1, double x2, double y2, double x3, double y3) //Задание 2
    {
        double ab = SegmentLength(x1, y1, x2, y2);
        double ac = SegmentLength(x1, y1, x3, y3);
        double cb = SegmentLength(x3, y3, x2, y2);
        string belonging = Math.Abs(ab - (ac + cb)) < double.Epsilon ? "принадлежит" : "не принадлежит";
        return string.Format($"Точка C({x3};{y3}) {belonging} отрезку [A({x1};{y1}); B({x2};{y2})]");
    }

    static string AngleType(double x1, double y1, double x2, double y2, double x3, double y3) // Задание 3
    {
        double ab = SegmentLength(x1, y1, x2, y2);
        double bc = SegmentLength(x2, y2, x3, y3);
        double ac = SegmentLength(x1, y1, x3, y3);
        if (ab + bc <= ac || ab + ac <= bc || ac + bc <= ab)
        {
            return $"Треугольник с точками A({x1};{y1}) B({x2};{y2}) C({x3};{y3}) не существует";
        }
        string angleType = Math.Abs(Math.Pow(ac, 2) - (Math.Pow(ab, 2) + Math.Pow(bc, 2))) < Double.Epsilon ? "прямой" :
            Math.Pow(ac, 2) < Math.Pow(ab, 2) + Math.Pow(bc, 2) ? "острый" : "тупой";
        return string.Format($"Угол образованный точками A({x1};{y1}) B({x2};{y2}) C({x3};{y3}) {angleType}");
    }
    
    static string PlaneEquation(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3) // Задание 4
    { // Есть 3 фиксированные точки в пространстве, 1 переменная. Составляем 3 вектора A1A, A1A2, A1A3. //Смешанное произведение компланарных векторов = 0. С помощью определителя раскладываю в уравнение
        double coefX = (y2 - y1)*(z3 - z1) - (z2-z1)*(y3-y1);
        double coefY = -((x2-x1)*(z3-z1) - (z2-z1)*(x3-x1));
        double coefZ = (x2-x1)*(y3-y1) - (y2-y1)*(x3-x1);
        int i = 0;
        while (true)
        {
            if (coefX != 0 || coefY != 0 || coefZ != 0)
            {
                break;
            }
            i++;
            double newX3 = x1 + i;
            coefX = (y2 - y1)*(z3 - z1) - (z2-z1)*(y3-y1);
            coefY = -((x2-x1)*(z3-z1) - (z2-z1)*(newX3-x1));
            coefZ = (x2-x1)*(y3-y1) - (y2-y1)*(newX3-x1);
        }
        double freeTerm = -(coefX * x1 + coefY * y1 + coefZ * z1);
        string signY = coefY >= 0 ? "+" : "-";
        string signZ = coefZ >= 0 ? "+" : "-";
        string signFreeTerm = freeTerm >= 0 ? "+" : "-";
        return string.Format(
            $"Общее уравнение плоскости, заданной точками A({x1};{y1};{z1}), B({x2};{y2};{z2}), C({x3};{y3};{z3}):\n" +
            $"{coefX:F8}x {signY} {Math.Abs(coefY):F8}y {signZ} {Math.Abs(coefZ):F8}z {signFreeTerm} {Math.Abs(freeTerm):F8} = 0");
    }

    static List<Tuple<double, double>> CirlceIntersection(double x1, double y1, double r1, double x2, double y2, double r2) // Задание 5
    {
        List<Tuple<double, double>> ans = new();
        double d = SegmentLength(x1, y1, x2, y2);
        double radiusSum = r1 + r2;
        double a, b, h;
        b = (Math.Pow(r2, 2) - Math.Pow(r1, 2) + Math.Pow(d, 2)) / (2 * d);
        a = d - b;
        h = Math.Sqrt(Math.Pow(r1, 2) - Math.Pow(a, 2));
        double p0x = Math.Round(x1 + a * (x2 - x1) / d,2);
        double p0y = Math.Round(y1 + a * (y2 - y1) / d,2);
        if(x1 == x2 && y1 == y2 && r1 == r2)
        {
            return ans;
        }
        if (Math.Abs(d - radiusSum) < Double.Epsilon) // Если равны, то окружности касаются в одной точке (
        {
            ans.Add(new Tuple<double, double>(p0x,p0y));
        }
        else if (d < radiusSum && Math.Abs(r1-r2) < d)
        {
            double p3x = Math.Round(p0x + h * (y2 - y1) / d,8);
            double p3y = Math.Round(p0y - h * (x2 - x1) / d,8);
            double p4x = Math.Round(p0x - h * (y2 - y1) / d,8);
            double p4y = Math.Round(p0y + h * (x2 - x1) / d,8);
            ans.Add(new Tuple<double, double>(p3x,p3y));
            ans.Add(new Tuple<double, double>(p4x,p4y));
        }
        return ans;
    }
    
}
