namespace easywallet_api.Response;

public class BaseResponse<T>
{
    public bool Success {get; set; }
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

    public static BaseResponse<T> SuccessResponse(T data, string message = "")
    {
        return new BaseResponse<T>
        {
            Success = true,
            Message = message,
            Data = data
        };
    }

    public static BaseResponse<T> FailResponse(string message)
    {
        return new BaseResponse<T>
        {
            Success = false,
            Message = message
        };
    }
}