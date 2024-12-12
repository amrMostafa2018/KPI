using System.Net;

namespace DFI.Application.Wrappers
{
    public class ResponseVM
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public ResponseMessageStatusEnum OperationStatus { get; set; } = ResponseMessageStatusEnum.Success;
        public string OperationMessage { get; set; }
        public object Data { get; set; }
        public object Error { get; set; }
    }

    public enum ResponseMessageStatusEnum
    {
        Success = 0,
        Failure = 1,
        InValidData = 2,
        Exception = 3,
        Unauthorized = 4,
        NotFound = 5,
        Forbidden = 6
    }
}