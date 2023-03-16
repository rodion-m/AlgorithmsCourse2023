using MyHashSetLib.Reversed;

namespace MyHashSetLib;

public class HashSetDemo
{
    public static void Run()
    {
        var points = new RHashSet<MyPoint>();
        Console.WriteLine(points.Add(new MyPoint(10, 22))); //true
        Console.WriteLine(points.Add(new MyPoint(50, 60))); //true
        Console.WriteLine(points.Add(new MyPoint(50, 60))); //false
        Console.WriteLine(points.Add(new MyPoint(60, 50))); //true: Коллизия, но значение другое
    }
    
    private class MyPoint
    {
        public int X { get; }
        public int Y { get; }
        
        public MyPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Специально делаем коллизии детерминируемыми
        public override int GetHashCode() => X + Y;

        public override bool Equals(object? obj)
            => obj is MyPoint other && other.X == X && other.Y == Y;
    }
}