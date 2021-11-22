namespace Api.CrossCutting.Dtos
{
    public class CommandReturnDto
    {
        public CommandReturnDto() { }
        public CommandReturnDto(bool success, string message, dynamic data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}