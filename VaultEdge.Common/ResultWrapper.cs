namespace VaultEdge.Common 
{
    public class ResultWrapper<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "OK";
        public T Data { get; set; }

        public static ResultWrapper<T> Ok(T data, string message = "OK")
        {
            return new ResultWrapper<T> { Data = data, Message = message };
        }

        public static ResultWrapper<T> Fail(string message)
        {
            return new ResultWrapper<T> { Success = false, Message = message };
        }
    }
}
