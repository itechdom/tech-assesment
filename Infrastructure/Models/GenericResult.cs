using Newtonsoft.Json;

namespace justice_technical_assestment.Models
{
    public class ResponseResult<T>
    {
        public Genericresult GenericResult { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public T ResponseData { get; set; }

        public ResponseResult()
        {
            GenericResult = new Genericresult();
        }

        public ResponseResult(T t)
        {
            GenericResult = new Genericresult();
            ResponseData = t;
        }
    }

    public class Genericresult
    {
        public string StatusCode { get; set; } = "1";
        public string UserFriendlyEnglishMessage { get; set; } = "Success";
        public string UserFriendlyArabicMessage { get; set; } = "Success AR";
        public string TechnicalErrorMessage { get; set; } = "";
    }
}
