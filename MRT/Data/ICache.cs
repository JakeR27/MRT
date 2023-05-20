namespace MRT.Data;

public interface ICache
{
    public TData Get<TData>(Guid id);
    public void Insert<TData>(TData record);
    public void Update<TData>(TData record);
}