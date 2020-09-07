
namespace SearchEngine.Core.Utilities.Results.Interface
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
