//Database msSQL = new();
//msSQL.Connection = new();
//msSQL.Connection.ConnectionString = "...";
//msSQL.Command = new();

//var result = msSQL.Connection.Connect();
//if (result && msSQL.Connection.State == ConnectionState.Open)
//{
//    msSQL.Command.Execute("Select * from ....");
//}
//msSQL.Connection.Disconnect();


//Database oracle = new();
//oracle.Connection = new();
//oracle.Connection.ConnectionString = "...";
//oracle.Command = new();

DatabaseCreator creator = new();
Database database = creator.Create(new OracleDatabaseFactory());
Database database2 = creator.Create(new MYSqlDatabaseFactory());


Console.WriteLine();


enum DatabaseType
{
    Oracle,
    MSSql,
    MYSql,
    PostgreSql
}
class Database
{
    public Database() { }
    public Database(DatabaseType type, Connection connection, Command command)
    {
        Type = type;
        Connection = connection;
        Command = command;
    }

    public DatabaseType Type { get; set; }
    public AbstractConnection Connection { get; set; }
    public AbstractCommand Command { get; set; }
}

enum ConnectionState
{
    Open, Close
}

//Abstract Product
abstract class AbstractConnection
{
    public abstract string ConnectionString { get; set; }
    public abstract ConnectionState State { get; set; }
    public abstract bool Connect();
    public abstract bool Disconnect();
}

//Abstract Product
abstract class AbstractCommand
{
    public abstract void Execute(string query);
}

//Concrete Product
class Connection : AbstractConnection
{
    string _connectionString;
    public Connection() { }
    public Connection(string connectionString)
        => _connectionString = connectionString;

    public override string ConnectionString { get => _connectionString; set => _connectionString = value; }
    public override ConnectionState State { get; set; }
    public override bool Connect()
    {
        //...işlemler yürütülüyor...
        State = ConnectionState.Open;
        return true;
    }
    public override bool Disconnect()
    {
        //..işlemler yürütülüyor...
        State = ConnectionState.Close;
        return true;
    }
}
//Concrete Product
class Command : AbstractCommand
{
    public override void Execute(string query)
    {
        //...executing...
    }
}

//Abstract Factory
abstract class DatabaseFactory
{
    public abstract AbstractConnection CreateConnection();
    public abstract AbstractCommand CreateCommand();
}

//Concrete Factory
class MSSqlDatabaseFactory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }

    public override AbstractConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "MSSQL connection string";
        return connection;
    }
}

//Concrete Factory
class OracleDatabaseFactory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }

    public override AbstractConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "Oracle connection string";
        return connection;
    }
}

//Concrete Factory
class MYSqlDatabaseFactory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }

    public override AbstractConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "MYSql connection string";
        return connection;
    }
}

//Concrete Factory
class PostgreSQLDatabaseFactory : DatabaseFactory
{
    public override AbstractCommand CreateCommand()
    {
        Command command = new();
        return command;
    }

    public override AbstractConnection CreateConnection()
    {
        Connection connection = new Connection();
        connection.ConnectionString = "PostgreSQL connection string";
        return connection;
    }
}

//Cretor
class DatabaseCreator
{
    AbstractConnection _connection;
    AbstractCommand _command;

    public Database Create(DatabaseFactory databaseFactory)
    {
        _connection = databaseFactory.CreateConnection();
        _command = databaseFactory.CreateCommand();


        return new()
        {
            Command = _command,
            Connection = _connection,
            Type = (DatabaseType)Enum.Parse(typeof(DatabaseType), databaseFactory.GetType().Name.Replace("DatabaseFactory", ""))
        };
    }
}