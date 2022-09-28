DatabaseCreator creator = new DatabaseCreator();
Database mysql = creator.Create(new MySqlDatabaseFactory());
Database mssql = creator.Create(new MsSqlDatabaseFactory());

Console.WriteLine();
//Abstract Product
enum ConnectionState
{
    Open, Close
}
abstract class Connection
{
    public abstract bool Connect();
    public abstract bool DisConnect();
    abstract public ConnectionState State { get; set; }

}
//Abstract Product
abstract class Command
{
    public abstract void Execute(string query);
}

//Concrete Product
class MsSqlConnection : Connection
{
    public override ConnectionState State { get; set; }

    public override bool Connect()
    {
        Console.WriteLine("MsSqlConnection bağlantısı gerçekleştirildi.");
        State = ConnectionState.Open;
        return true;
    }

    public override bool DisConnect()
    {
        Console.WriteLine("MsSqlConnection bağlantısı koparıldı.");
        State = ConnectionState.Close;
        return true;
    }
}
//Concrete Product
class MySqlConnection : Connection
{
    public override ConnectionState State { get; set; }

    public override bool Connect()
    {
        Console.WriteLine("MySqlConnection bağlantısı gerçekleştirildi.");
        State = ConnectionState.Open;
        return true;
    }

    public override bool DisConnect()
    {
        Console.WriteLine("MySqlConnection bağlantısı koparıldı.");
        State = ConnectionState.Close;
        return true;
    }
}
//Concrete Product
class MsSqlCommand : Command
{
    public override void Execute(string query)
    {
        Console.WriteLine(query);
    }
}
//Concrete Product
class MySqlCommand : Command
{
    public override void Execute(string query)
    {
        Console.WriteLine(query);
    }
}

//Abstract Factory
abstract class DatabaseFactory
{
    public abstract Connection CreateConnection();
    public abstract Command CreateCommand();
}
//Concrete Factory
class MsSqlDatabaseFactory : DatabaseFactory
{
    public override Command CreateCommand()
    {
        MsSqlCommand command = new();
        return command;
    }

    public override Connection CreateConnection()
    {
        MsSqlConnection connection = new();
        //connection string set
        return connection;
    }
}
//Concrete Factory
class MySqlDatabaseFactory : DatabaseFactory
{
    public override Command CreateCommand()
    {
        MySqlCommand command = new();
        return command;
    }

    public override Connection CreateConnection()
    {
        MySqlConnection connection = new();
        //connection string set
        return connection;
    }
}
//Creator
class DatabaseCreator
{
    public Database Create(DatabaseFactory databaseFactory)
    {
        return new Database()
        {
            Command = databaseFactory.CreateCommand(),
            Connection = databaseFactory.CreateConnection()
        };
    }
}

class Database
{
    public Connection Connection { get; set; }
    public Command Command { get; set; }
}