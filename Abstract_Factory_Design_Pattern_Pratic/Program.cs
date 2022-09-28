//Computer computer1 = new();

//CPU cpu = new();
//computer1.CPU = cpu;

//RAM ram = new();
//computer1.RAM = ram;

//VideoCard videoCard = new();
//computer1.VideoCard = videoCard;

//Computer computer2 = new(new(), new(), new());

//CPU cpu2 = ;
//computer2.CPU = cpu2;

//RAM ram2 = new();
//computer2.RAM = ram2;

//VideoCard videoCard2 = new();
//computer2.VideoCard = videoCard2;

ComputerCreator creator = new();
Computer asus = creator.CreateComputer(new AsusFactory());
Computer toshiba = creator.CreateComputer(new ToshibaFactory());

class Computer
{
    public Computer(ICPU cPU, IRAM rAM, IVideoCard videoCard)
    {
        CPU = cPU;
        RAM = rAM;
        VideoCard = videoCard;
    }
    public Computer()
    {

    }

    public ICPU CPU { get; set; }
    public IRAM RAM { get; set; }
    public IVideoCard VideoCard { get; set; }
}
#region Abstract Products
interface ICPU { }
interface IRAM { }
interface IVideoCard { }
#endregion

#region Concrete Products
class CPU : ICPU
{
    public CPU(string text)
        => Console.WriteLine(text);
}
class RAM : IRAM
{
    public RAM(string text)
        => Console.WriteLine(text);
}
class VideoCard : IVideoCard
{
    public VideoCard(string text)
        => Console.WriteLine(text);
}
#endregion

#region Abstract Factory
interface IComputerFactory
{
    ICPU CreateCPU();
    IRAM CreateRAM();
    IVideoCard CreateVideoCard();
}
#endregion
#region Cocnrete Factories
class AsusFactory : IComputerFactory
{
    public ICPU CreateCPU()
        => new CPU($"Asus CPU üretildi.");

    public IRAM CreateRAM()
        => new RAM("Asus RAM üretildi.");

    public IVideoCard CreateVideoCard()
        => new VideoCard("Asus Video Card Üretildi");
}
class ToshibaFactory : IComputerFactory
{
    public ICPU CreateCPU()
        => new CPU($"Toshiba CPU üretildi.");

    public IRAM CreateRAM()
        => new RAM("Toshiba RAM üretildi.");

    public IVideoCard CreateVideoCard()
        => new VideoCard("Toshiba Video Card Üretildi");
}
class MSIFactory : IComputerFactory
{
    public ICPU CreateCPU()
        => new CPU($"MSI CPU üretildi.");

    public IRAM CreateRAM()
        => new RAM("MSI RAM üretildi.");

    public IVideoCard CreateVideoCard()
        => new VideoCard("MSI Video Card Üretildi");
}
#endregion
#region Creator
class ComputerCreator
{
    ICPU _cpu;
    IRAM _ram;
    IVideoCard _videoCard;

    public Computer CreateComputer(IComputerFactory computerFactory)
    {
        _cpu = computerFactory.CreateCPU();
        _ram = computerFactory.CreateRAM();
        _videoCard = computerFactory.CreateVideoCard();

        return new(_cpu, _ram, _videoCard);
    }
}
#endregion