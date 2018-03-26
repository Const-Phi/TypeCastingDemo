namespace TypeCastingDemo
{
    internal static class Staff
    {
        internal static bool IsNear(double lha, double rha, double eps = double.Epsilon) =>
            System.Math.Abs(lha - rha) <= eps;
    }
}