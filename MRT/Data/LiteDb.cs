using System.Linq.Expressions;
using LiteDB;
using MRT.Data.ResultModels;

namespace MRT.Data;

public class LiteDb : IDatabase
{
    private static LiteDb _instance;
    public LiteDatabase Database { get; }
    
    private LiteDb()
    {
        var connectionString = new ConnectionString("E:/Programming/C#/MRT/MRT/mrt.db")
        {
            Connection = ConnectionType.Shared
        };
        Database = new LiteDatabase(connectionString);
    }
    public static LiteDb Instance()
    {
        return _instance ??= new LiteDb();
    }

    public void Insert<TData>(TData record, string collection)
    {
        Instance().Database.GetCollection<TData>(collection).Insert(record);
    }

    public TData Get<TData>(Guid id, string collection) where TData : IModel
    {
        return Instance().Database.GetCollection<TData>(collection).FindOne(record => record.Id == id);
    }

    public List<TData> Get<TData>(string collection)
    {
        return Instance().Database.GetCollection<TData>(collection).FindAll().ToList();
    }

    public List<TData> Get<TData>(string collection, Expression<Func<TData, bool>> predicate)
    {
        return Instance().Database.GetCollection<TData>(collection).Find(predicate).ToList();
    }

    public bool Update<TData>(TData record, string collection) where TData : IModel
    {
        return Instance().Database.GetCollection<TData>(collection).Update(record);
    }
}