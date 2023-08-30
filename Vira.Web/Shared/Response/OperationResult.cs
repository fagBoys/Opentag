namespace Vira.Web.Shared
{
    public class OperationResult<T>
    {
        public T? Data { get; set; }
        public bool isSuccedded { get; set; }
        public string Message { get; set; }


        public OperationResult()
        {
            isSuccedded = false;

        }
        public OperationResult<T> Succedded( string message = "عملیات با موفقیت انجام شد")
        {
            isSuccedded = true;
            Message = message;  
            return this;
        }

        public OperationResult<T> Failed(string message)
        {
            isSuccedded = false;
            Message = message;
            return this;
        }
    }
}
