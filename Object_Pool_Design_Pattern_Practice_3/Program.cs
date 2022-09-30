using System.Collections.Concurrent;

ObjectPool<X> pool = ObjectPool<X>.GetInstance;
var t1 = Task.Run(() =>
{
    while (true)
    {
        var x = pool.Get(() => new X());
        if (x != null)
        {
            x.Count++;
            x.Write();
            pool.Return(x);
        }
    }
});
var t2 = Task.Run(() =>
{
    while (true)
    {
        var x = pool.Get(() => new X());
        if (x != null)
        {
            x.Count++;
            x.Write();
            pool.Return(x);
        }
    }
});

await Task.WhenAll(t1, t2);

//ConcurrentBag;
/*
 Asenkron süreçlerde kullanılan Thread Safe bir koleksiyondur.
 Tüm thread'ler için bu koleksiyon nesnesinden bir model oluşturulmakta ve her bir iş parçacığı kendisine ait model üzerinden çalışmaktadır. Böylece çakışma söz konusu olmamamktadır. 
 Her bir thread için, eklenen en sonuncu elemean elde edilir. Dolayısıyla herhangi bir thread'de elemen eklenmediği durumlarda en sonuncu eleman istenildiği taktirde diğer thread'ler tarafından son eleman olarak eklenenlerden biri rastgele alınacak ve geri gönderilecektir.
 */

class ObjectPool<T> where T : class
{
    //Pool
    readonly ConcurrentBag<T> _instances;
    readonly List<string> _types = new();
    ObjectPool()
        => _instances = new();

    static ObjectPool<T> _objectPool;
    static ObjectPool()
        => _objectPool = new ObjectPool<T>();
    static public ObjectPool<T> GetInstance { get => _objectPool; }
    static object _o = new();

    public ConcurrentBag<T> Instances { get => _instances; }
    public T Get(Func<T>? objectGenerator = null)
    {

        lock (_o)
        {
            var state = _instances.TryTake(out T instance);
            if (!state && !_types.Any(t => t == nameof(T)))
            {
                T generatedInstance = objectGenerator();
                _types.Add(nameof(T));
                return generatedInstance;
            }
            return instance;

            //Havuzdan generic parametrede bildirilen türdeki nesneyi geri döndürmek.
        }
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