using Microsoft.Extensions.ObjectPool;

DefaultObjectPoolProvider provider = new();
ObjectPool<X> pool = provider.Create(new DefaultPooledObjectPolicy<X>());

var x1 = pool.Get();
x1.Count++;
x1.Write();
pool.Return(x1);

var x2 = pool.Get();
x2.Count++;
x2.Write();
pool.Return(x2);

var x3 = pool.Get();
x3.Count++;
x3.Write();
pool.Return(x3);

Console.WriteLine();
class X
{
    public int Count { get; set; }
    public void Write()
        => Console.WriteLine(Count);

    public X()
        => Console.WriteLine("X üretim maliyeti...");

    ~X()
        => Console.WriteLine("X imha maliyeti...");
}