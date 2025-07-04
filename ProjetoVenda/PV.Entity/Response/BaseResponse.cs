namespace PV.Entity.Response
{
    public abstract class BaseResponse
    {
        public string Message { get;set; }
        public bool IsSucess { get; set; }

        public BaseResponse(bool isSucess, string message) 
        { 
            IsSucess = isSucess;
            Message = message;
        }
    }
}
