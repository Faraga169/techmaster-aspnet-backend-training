namespace task_06_api_standards_refactor_pack.Exceptions
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
