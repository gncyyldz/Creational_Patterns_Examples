/*
////Mercedes
//Araba mercedes = new();
//mercedes.KM = 0;
//mercedes.Marka = "Mercedes";
//mercedes.Model = "...";
//mercedes.Vites = true;

////BMW
//Araba bmw = new();
//bmw.KM = 10;
//bmw.Marka = "BMW";
//bmw.Model = "...";
//bmw.Vites = false;
*/

ArabaDirector director = new();
Araba opel = director.Build(new OpelBuilder());
opel.ToString();
Araba mercedes = director.Build(new MercedesBuilder());
mercedes.ToString();
Araba bmw = director.Build(new BMWBuilder());
bmw.ToString();

//Product
class Araba
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public double KM { get; set; }
    public bool Vites { get; set; }
    public override string ToString()
    {
        Console.WriteLine($"{Marka} marka araba {Model} modelinde {KM} kilometrede {Vites} vites olarak üretilmiştir.");
        return base.ToString();
    }
}

#region Interface İle Abstract Builder'in Tasarlanması
////Abstract Builder
//interface IArabaBuilder
//{
//    Araba Araba { get; }
//    IArabaBuilder SetMarka();
//    IArabaBuilder SetModel();
//    IArabaBuilder SetKM();
//    IArabaBuilder SetVites();
//}
////Concrete Builder
//class OpelBuilder : IArabaBuilder
//{
//    public Araba Araba { get; }
//    public OpelBuilder()
//        => Araba = new();

//    public IArabaBuilder SetKM()
//    {
//        Araba.KM = 0;
//        return this;
//    }

//    public IArabaBuilder SetMarka()
//    {
//        Araba.Marka = "Opel";
//        return this;
//    }

//    public IArabaBuilder SetModel()
//    {
//        Araba.Model = "...";
//        return this;
//    }

//    public IArabaBuilder SetVites()
//    {
//        Araba.Vites = true;
//        return this;
//    }
//}
////Concrete Builder
//class MercedesBuilder : IArabaBuilder
//{
//    public Araba Araba { get; }
//    public MercedesBuilder()
//        => Araba = new();
//    public IArabaBuilder SetKM()
//    {
//        Araba.KM = 100;
//        return this;
//    }

//    public IArabaBuilder SetMarka()
//    {
//        Araba.Marka = "Mercedes";
//        return this;
//    }

//    public IArabaBuilder SetModel()
//    {
//        Araba.Model = "xyz";
//        return this;
//    }

//    public IArabaBuilder SetVites()
//    {
//        Araba.Vites = true;
//        return this;
//    }
//}
////Concrete Builder
//class BMWBuilder : IArabaBuilder
//{
//    public Araba Araba { get; }
//    public BMWBuilder()
//        => Araba = new();
//    public IArabaBuilder SetKM()
//    {
//        Araba.KM = 10;
//        return this;
//    }

//    public IArabaBuilder SetMarka()
//    {
//        Araba.Marka = "BMW";
//        return this;
//    }

//    public IArabaBuilder SetModel()
//    {
//        Araba.Model = "XY5";
//        return this;
//    }

//    public IArabaBuilder SetVites()
//    {
//        Araba.Vites = false;
//        return this;
//    }
//}

////Director
//class ArabaDirector
//{
//    public Araba Build(IArabaBuilder arabaBuilder)
//    {
//        //arabaBuilder.SetMarka();
//        //arabaBuilder.SetModel();
//        //arabaBuilder.SetKM();
//        //arabaBuilder.SetVites();
//        arabaBuilder.SetMarka()
//            .SetModel()
//            .SetKM()
//            .SetVites();
//        return arabaBuilder.Araba;
//    }
//}
#endregion
#region Abstract Class İle Abstract Builder'in Tasarlanması
//Abstract Builder
abstract class ArabaBuilder
{
    protected Araba araba;
    public Araba Araba { get => araba; }
    public ArabaBuilder()
        => araba = new();
    public abstract ArabaBuilder SetMarka();
    public abstract ArabaBuilder SetModel();
    public abstract ArabaBuilder SetKM();
    public abstract ArabaBuilder SetVites();
}
//Concrete Builder
class OpelBuilder : ArabaBuilder
{
    public override ArabaBuilder SetKM()
    {
        araba.KM = 0;
        return this;
    }

    public override ArabaBuilder SetMarka()
    {
        araba.Marka = "Opel";
        return this;
    }

    public override ArabaBuilder SetModel()
    {
        araba.Model = "...";
        return this;
    }

    public override ArabaBuilder SetVites()
    {
        araba.Vites = true;
        return this;
    }
}
//Concrete Builder
class MercedesBuilder : ArabaBuilder
{
    public override ArabaBuilder SetKM()
    {
        araba.KM = 100;
        return this;
    }

    public override ArabaBuilder SetMarka()
    {
        araba.Marka = "Mercedes";
        return this;
    }

    public override ArabaBuilder SetModel()
    {
        araba.Model = "xyz";
        return this;
    }

    public override ArabaBuilder SetVites()
    {
        araba.Vites = true;
        return this;
    }
}
//Concrete Builder
class BMWBuilder : ArabaBuilder
{
    public override ArabaBuilder SetKM()
    {
        araba.KM = 10;
        return this;
    }

    public override ArabaBuilder SetMarka()
    {
        araba.Marka = "BMW";
        return this;
    }

    public override ArabaBuilder SetModel()
    {
        araba.Model = "XY5";
        return this;
    }

    public override ArabaBuilder SetVites()
    {
        araba.Vites = false;
        return this;
    }
}

//Director
class ArabaDirector
{
    public Araba Build(ArabaBuilder arabaBuilder)
    {
        //arabaBuilder.SetMarka();
        //arabaBuilder.SetModel();
        //arabaBuilder.SetKM();
        //arabaBuilder.SetVites();
        arabaBuilder.SetMarka()
            .SetModel()
            .SetKM()
            .SetVites();
        return arabaBuilder.Araba;
    }
}
#endregion