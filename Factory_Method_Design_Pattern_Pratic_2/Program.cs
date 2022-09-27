while (true)
{
    for (int i = 0; i < 100; i++)
    {
        try
        {
            A? a = ProductCreator.GetInstance(ProductType.A) as A;
            a.Run();

            B? b = ProductCreator.GetInstance(ProductType.B) as B;
            b.Run();


        }
        catch (Exception ex)
        {

            throw;
        }
    }
}

#region Abstract Product
interface IProduct
{
    void Run();
}
#endregion
#region Concrete Products
class A : IProduct
{
    public A()
    {
        Console.WriteLine($"{nameof(A)} nesnesi üretildi.");
    }
    public void Run()
    {
        throw new NotImplementedException();
    }
}

class B : IProduct
{
    public B()
    {
        Console.WriteLine($"{nameof(B)} nesnesi üretildi.");
    }
    public void Run()
    {
        throw new NotImplementedException();
    }
}

class C : IProduct
{
    public C()
    {
        Console.WriteLine($"{nameof(C)} nesnesi üretildi.");
    }
    public void Run()
    {
        throw new NotImplementedException();
    }
}
#endregion

#region Abstract Factory
interface IFactory
{
    IProduct CreateProduct();
}
#endregion

#region Concrete Factories
class AFactory : IFactory
{
    public IProduct CreateProduct()
    {
        A a = new A();
        return a;
    }
}
class BFactory : IFactory
{
    public IProduct CreateProduct()
    {
        B b = new B();
        return b;
    }
}
class CFactory : IFactory
{
    public IProduct CreateProduct()
    {
        C c = new C();
        return c;
    }

}
#endregion

#region Creator
enum ProductType
{
    A, B, C
}
class ProductCreator
{
    static public IProduct GetInstance(ProductType productType)
    {
        IFactory _factory = productType switch
        {
            ProductType.A => new AFactory(),
            ProductType.B => new BFactory(),
            ProductType.C => new CFactory()
        };
        return _factory.CreateProduct();
    }
}
#endregion