
namespace Common
{
    public class BaseResponse<T>
    {
        public T results { get; set; }
        public string message { get; set; }
        public string status { get; set; }
    }
}
