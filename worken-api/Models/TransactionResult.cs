namespace worken_api.Models
{
    public class TransactionResult
    {
        public string Result { get; }
        public Exception Exception { get; }

        public TransactionResult(string result, Exception exception = null)
        {
            Result = result;
            Exception = exception;
        }
    }
}