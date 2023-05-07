using LiteDB;

namespace MRT.Data;

public class LiteDb
{
    private static LiteDb _instance;
    public LiteDatabase Database { get; }
    
    private LiteDb()
    {
        var connectionString = new ConnectionString($"{Environment.CurrentDirectory}/mrt.db")
        {
            Connection = ConnectionType.Shared
        };
        Database = new LiteDatabase(connectionString);
    }
    public static LiteDb Instance()
    {
        return _instance ??= new LiteDb();
    }
    
}