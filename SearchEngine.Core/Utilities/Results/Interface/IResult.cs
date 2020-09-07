
namespace SearchEngine.Core.Utilities.Results.Interface
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}
