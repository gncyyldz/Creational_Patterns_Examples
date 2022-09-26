List<Task> tasks = new();

for (int i = 0; i < 100; i++)
{
    tasks.Add(Task.Run(() =>
        {
            Example.GetInstance();
        }));
}


await Task.WhenAll(tasks);

class Example
{
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} nesnesi oluşturulmuştur.");
    }
    static Example()
    {
        _example = new Example();
    }

    static Example _example;
    //static object _obj = new object();
    static public Example GetInstance()
    {
        //lock (_obj)
        //{
        //    if (_example == null)
        //        _example = new Example();
        //}

        return _example;
    }
}