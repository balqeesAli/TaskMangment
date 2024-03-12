namespace TaskMangmentAPI.Infrastructure.DTOs
{
    public class ResponseModel<T>
    {
        public string message { get; set; } = "Success";
        public int result { get; set; } = 200;
        public T? body { get; set; }

        public ResponseModel()
        {

        }

        internal ResponseModel(T? body, string msg = "Success")
        {
            this.body = body;
            this.message = msg;
        }
        internal ResponseModel(int result, string msg)
        {
            this.message = msg;
            this.result = result;
            this.body = default;
        }

        public static ResponseModel<T> Success(T? body, string msg = "Success")
        {
            return new ResponseModel<T>(body, msg);
        }
        public static ResponseModel<T> Fail(int result, string msg)
        {
            return new ResponseModel<T>(result, msg);
        }
        public static ResponseModel<T> UnAuthorized()
        {
            return new ResponseModel<T>(401, "Unauthorized");
        } 
    }
}
