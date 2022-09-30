namespace Object_Pool_Design_Pattern_CSharp_AspNetCore_Example.Classes
{
    public class X
    {
        public int Count { get; set; }
        public void Write()
            => Console.WriteLine(Count);

        public X()
            => Console.WriteLine("X üretim maliyeti...");

        ~X()
            => Console.WriteLine("X imha maliyeti...");
    }
}
