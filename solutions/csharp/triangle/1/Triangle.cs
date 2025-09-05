public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        if (!IsValidTriangle(side1, side2, side3)) return false;
        return side1 != side2 && side2 != side3 && side1 != side3;
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        if (!IsValidTriangle(side1, side2, side3)) return false;
        return side1 == side2 || side1 == side3 || side2 == side3;
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        if (!IsValidTriangle(side1, side2, side3)) return false;
        return side1 == side2 && side2 == side3;
    }

    public static bool IsValidTriangle(double a, double b, double c){
        return a > 0 && b > 0 && c > 0 &&
               a + b > c && b + c > a && a + c > b;
        }
}