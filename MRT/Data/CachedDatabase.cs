using System.Linq.Expressions;
using MRT.Data.ResultModels;

namespace MRT.Data;

public class CachedDatabase : IDatabase
{
    private IDatabase _database;
    private Dictionary<Guid, object> _cache = new();

    private CachedDatabase() { }

    public CachedDatabase(IDatabase database)
    {
        _database = database;
    }

    public bool Insert<TData>(TData record, string collection) where TData : IModel
    {
        if (record.Id == Guid.Empty) return false;

        //try to add to cache, record if successful
        var cached = _cache.TryAdd(record.Id, record);

        //try to add to database, record if successful
        var persisted = _database.Insert(record, collection);
        
        // dont record cached, but not actually in database, so remove from cache
        if (!persisted && cached)
        {
            _cache.Remove(record.Id);
        }

        return cached && persisted;
    }

    public TData? Get<TData>(Guid id, string collection) where TData : IModel
    {
        if (id == Guid.Empty) return default;

        if (_cache.TryGetValue(id, out var record))
        {
            return (TData)record;
        }

        return _database.Get<TData>(id, collection);
    }

    public List<TData> Get<TData>(string collection) where TData : IModel
    {
        // cant get results from cache when given no specific record
        // just call the database
        return _database.Get<TData>(collection);
    }

    public List<TData> Get<TData>(string collection, Expression<Func<TData, bool>> predicate) where TData : IModel
    {
        // cant get results from cache when given no specific record
        // just call the database
        return _database.Get<TData>(collection);
    }

    public bool Update<TData>(TData record, string collection) where TData : IModel
    {
        if (record.Id == Guid.Empty) return false;

        _cache[record.Id] = record;
        _database.Update(record, collection);
        
        return true;
    }
}