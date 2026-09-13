namespace StudentManagementAPI.Exceptions
{
    public class BusinessException:Exception
    {
        
        public BusinessException(string message,int statuscode):base(message)
        {
            StatusCode = statuscode;
        }

        public int StatusCode { get; }
    }
}
