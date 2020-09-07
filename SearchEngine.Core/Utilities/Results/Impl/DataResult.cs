using SearchEngine.Core.Utilities.Results.Interface;

namespace SearchEngine.Core.Utilities.Results.Impl
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public T Data { get; }

        public DataResult(T data, bool isSuccess, string message) : base(isSuccess, message)
        {
            Data = data;
        }

        public DataResult(T data, bool isSuccess) : base(isSuccess)
        {
            Data = data;
        }
    }
}
