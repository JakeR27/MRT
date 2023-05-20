using System.Linq.Expressions;
using MRT.Data.ResultModels;

namespace MRT.Data;

public interface IDatabase
{
    public void Insert<TData>(TData record, string collection) where TData : IModel;
    public TData? Get<TData>(Guid id, string collection) where TData : IModel;
    public List<TData> Get<TData>(string collection) where TData : IModel;
    public List<TData> Get<TData>(string collection, Expression<Func<TData, bool>> predicate) where TData : IModel;
    public bool Update<TData>(TData record, string collection) where TData : IModel;
}