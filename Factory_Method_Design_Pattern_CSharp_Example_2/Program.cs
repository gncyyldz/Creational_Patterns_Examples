//GarantiBank garantiBank = new("asd", "123");
//garantiBank.ConnectGaranti();


//VakifBank vakifBank = new(new() { UserCode = "gncy", Mail = "gncy@gencayyildiz.com" }, "123");
//bool result = vakifBank.ValidateCredential();
//if (result)
//{
//    //...
//}

//HalkBank halkBank = new("gncy");
//halkBank.Password = "123";

BankCreator bankCreator = new();
GarantiBank? garanti = bankCreator.Create(BankType.Garanti) as GarantiBank;
HalkBank? halkBank = bankCreator.Create(BankType.Halkbank) as HalkBank;
VakifBank? vakifbank = bankCreator.Create(BankType.Vakifbank) as VakifBank;

GarantiBank? garanti2 = bankCreator.Create(BankType.Garanti) as GarantiBank;
HalkBank? halkBank2 = bankCreator.Create(BankType.Halkbank) as HalkBank;
VakifBank? vakifbank2 = bankCreator.Create(BankType.Vakifbank) as VakifBank;

GarantiBank? garanti3 = bankCreator.Create(BankType.Garanti) as GarantiBank;
HalkBank? halkBank3 = bankCreator.Create(BankType.Halkbank) as HalkBank;
VakifBank? vakifbank3 = bankCreator.Create(BankType.Vakifbank) as VakifBank;



#region Abstract Product
interface IBank
{

}
#endregion

#region Concrete Products
class GarantiBank : IBank
{
    string _userCode, _password;
    GarantiBank(string userCode, string password)
    {
        Console.WriteLine($"{nameof(GarantiBank)} nesnesi oluşturuldu.");
        _userCode = userCode;
        _password = password;
    }
    static GarantiBank()
        => _garantiBank = new("asd", "123");
    static GarantiBank _garantiBank;
    static public GarantiBank GetInstance => _garantiBank;

    public void ConnectGaranti()
        => Console.WriteLine($"{nameof(GarantiBank)} - Connected.");
    public void SendMoney(int amount)
        => Console.WriteLine($"{amount} money sent.");
}

class HalkBank : IBank
{
    string _userCode, _password;
    HalkBank(string userCode)
    {
        Console.WriteLine($"{nameof(HalkBank)} nesnesi oluşturuldu.");
        _userCode = userCode;
    }
    static HalkBank()
       => _halkBank = new("asd");
    static HalkBank _halkBank;
    static public HalkBank GetInstance => _halkBank;

    public string Password { set => _password = value; }

    public void Send(int amount, string accountNumber)
        => Console.WriteLine($"{amount} money sent.");
}

class CredentialVakifBank
{
    public string UserCode { get; set; }
    public string Mail { get; set; }
}
class VakifBank : IBank
{
    string _userCode, _email, _password;
    public bool isAuthentcation { get; set; }
    VakifBank(CredentialVakifBank credential, string password)
    {
        Console.WriteLine($"{nameof(VakifBank)} nesnesi oluşturuldu.");
        _userCode = credential.UserCode;
        _email = credential.Mail;
        _password = password;
    }

    static VakifBank()
      => _vakifBank = new(new() { Mail = "gncy@gencayyildiz.com", UserCode = "gncy" }, "123");
    static VakifBank _vakifBank;
    static public VakifBank GetInstance => _vakifBank;

    public void ValidateCredential()
    {
        if (true) //validating
            isAuthentcation = true;
    }

    public void SendMoneyToAccountNumber(int amount, string recipientName, string accountNumber)
        => Console.WriteLine($"{amount} money sent.");
}
#endregion

#region Abstract Factory
interface IBankFactory
{
    IBank CreateInstance();
}
#endregion
#region Concrete Factories
class GarantiFactory : IBankFactory
{
    GarantiFactory() { }
    static GarantiFactory()
        => _garantiFactory = new();
    static GarantiFactory _garantiFactory;
    static public GarantiFactory GetInstance => _garantiFactory;
    public IBank CreateInstance()
    {
        GarantiBank garanti = GarantiBank.GetInstance;
        garanti.ConnectGaranti();
        return garanti;
    }
}
class HalkBankFactory : IBankFactory
{
    HalkBankFactory() { }
    static HalkBankFactory()
        => _halkBankFactory = new();
    static HalkBankFactory _halkBankFactory;
    static public HalkBankFactory GetInstance => _halkBankFactory;

    public IBank CreateInstance()
    {
        HalkBank halkBank = HalkBank.GetInstance;
        halkBank.Password = "123";
        return halkBank;
    }
}
class VakifBankFactory : IBankFactory
{
    VakifBankFactory() { }
    static VakifBankFactory()
        => _vakifBankFactory = new();
    static VakifBankFactory _vakifBankFactory;
    static public VakifBankFactory GetInstance => _vakifBankFactory;
    public IBank CreateInstance()
    {
        VakifBank vakifBank = VakifBank.GetInstance;
        vakifBank.ValidateCredential();
        return vakifBank;
    }
}
#endregion

#region Creator
enum BankType
{
    Garanti, Halkbank, Vakifbank
}
class BankCreator
{
    public IBank Create(BankType bankType)
    {
        IBankFactory _bankFactory = bankType switch
        {
            BankType.Vakifbank => VakifBankFactory.GetInstance,
            BankType.Halkbank => HalkBankFactory.GetInstance,
            BankType.Garanti => GarantiFactory.GetInstance
        };

        return _bankFactory.CreateInstance();
    }
}
#endregion