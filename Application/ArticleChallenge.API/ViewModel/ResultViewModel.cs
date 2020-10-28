namespace ArticleChallenge.API.ViewModel
{
    public class ResultViewModel
    {
        public string Message { get; private set; }
        public bool Success { get; private set; }
        public dynamic Data { get; private set; }

        public ResultViewModel(string message, bool success, dynamic data)
        {
            Message = message;
            Success = success;
            Data = data;
        }
    }
}
