namespace _003
{
    public class CustomApiResponse
    {
        public static CustomApiResponse Create(int statusCode, object result, string requestId)
        {
            return new CustomApiResponse(statusCode, result, requestId);
        }

        internal CustomApiResponse(int statusCode, object result, string requestId)
        {
            Status = statusCode;
            RequestId = requestId;
            Result = result;
        }

        public int Status { get; set; }
        public string RequestId { get; set; }
        public object Result { get; set; }
    }
}
