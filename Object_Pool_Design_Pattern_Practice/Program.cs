using System.Collections.Concurrent;

ObjectPool<X> pools = new ObjectPool<X>();
var x1 = pools.Get(() => new X());
x1.Count++;
//....
pools.Return(x1);

var x2 = pools.Get(() => new X());
x2.Count++;
pools.Return(x2);

var x3 = pools.Get(() => new X());
x3.Count++;
pools.Return(x3);

Console.WriteLine();

class ObjectPool<T> where T : class
{
    //Pool
    readonly ConcurrentBag<T> _instances;
    public ObjectPool()
    {
        _instances = new();
    }
    public ConcurrentBag<T> Instances { get => _instances; }
    public T Get(Func<T>? objectGenerator = null)
    {
        //Havuzdan generic parametrede bildirilen türdeki nesneyi geri döndürmek.
        return _instances.TryTake(out T instance) ? instance : objectGenerator();
    }

    public void Return(T instance)
    {
        //Havuzdan ödünç alınan nesneyi geri iade etmek.
        _instances.Add(instance);
    }

}

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