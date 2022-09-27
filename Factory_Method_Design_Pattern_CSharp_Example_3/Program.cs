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

using System.Reflection;

BankCreator bankCreator = new();
GarantiBank? garanti = bankCreator.Create(BankType.Garanti) as GarantiBank;
HalkBank? halkBank = bankCreator.Create(BankType.HalkBank) as HalkBank;
VakifBank? vakifbank = bankCreator.Create(BankType.VakifBank) as VakifBank;

GarantiBank? garanti2 = bankCreator.Create(BankType.Garanti) as GarantiBank;
HalkBank? halkBank2 = bankCreator.Create(BankType.HalkBank) as HalkBank;
VakifBank? vakifbank2 = bankCreator.Create(BankType.VakifBank) as VakifBank;

GarantiBank? garanti3 = bankCreator.Create(BankType.Garanti) as GarantiBank;
HalkBank? halkBank3 = bankCreator.Create(BankType.HalkBank) as HalkBank;
VakifBank? vakifbank3 = bankCreator.Create(BankType.VakifBank) as VakifBank;



#region Abstract Product
interface IBank
{

}
#endregion

#region Concrete Products
class GarantiBank : IBank
{
    string _userCode, _password;
    public GarantiBank(string userCode, string password)
    {
        Console.WriteLine($"{nameof(GarantiBank)} nesnesi oluşturuldu.");
        _userCode = userCode;
        _password = password;
    }

    public void ConnectGaranti()
        => Console.WriteLine($"{nameof(GarantiBank)} - Connected.");
    public void SendMoney(int amount)
        => Console.WriteLine($"{amount} money sent.");
}

class HalkBank : IBank
{
    string _userCode, _password;
    public HalkBank(string userCode)
    {
        Console.WriteLine($"{nameof(HalkBank)} nesnesi oluşturuldu.");
        _userCode = userCode;
    }

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
    public VakifBank(CredentialVakifBank credential, string password)
    {
        Console.WriteLine($"{nameof(VakifBank)} nesnesi oluşturuldu.");
        _userCode = credential.UserCode;
        _email = credential.Mail;
        _password = password;
    }
    public void ValidateCredential()
    {
        if (true) //validating
            isAuthentcation = true;
    }

    public void SendMoneyToAccountNumber(int amount, string recipientName, string accountNumber)
        => Console.WriteLine($"{amount} money sent.");
}

class IsBank : IBank
{

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
    public IBank CreateInstance()
    {
        GarantiBank garanti = new("asd", "123");
        garanti.ConnectGaranti();
        return garanti;
    }
}
class HalkBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        HalkBank halkBank = new("asd");
        halkBank.Password = "123";
        return halkBank;
    }
}
class VakifBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        VakifBank vakifBank = new(new() { Mail = "gncy@gencayyildiz.com", UserCode = "gncy" }, "123");
        vakifBank.ValidateCredential();
        return vakifBank;
    }
}
class IsBankFactory : IBankFactory
{
    public IBank CreateInstance()
    {
        return new IsBank();
    }
}

#endregion

#region Creator
enum BankType
{
    Garanti, HalkBank, VakifBank, IsBank
}
class BankCreator
{
    public IBank Create(BankType bankType)
    {
        //IBankFactory _bankFactory = bankType switch
        //{
        //    BankType.Vakifbank => new VakifBankFactory(),
        //    BankType.Halkbank => new HalkBankFactory(),
        //    BankType.Garanti => new GarantiFactory(),
        //    BankType.IsBank => new IsBankFactory()
        //};

        //return _bankFactory.CreateInstance();

        string factory = $"{bankType.ToString()}Factory";
        Type? type = Assembly.GetExecutingAssembly().GetType(factory);
        IBankFactory? bankFactory = Activator.CreateInstance(type) as IBankFactory;
        return bankFactory.CreateInstance();
    }
}
#endregion