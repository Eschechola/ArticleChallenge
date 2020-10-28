using ArticleChallenge.API.ViewModel;

namespace ArticleChallenge.API.Utilities
{
    public static class ResultTemplates
    {
        public static ResultViewModel InternalServerError()
        {
            return new ResultViewModel
                (
                  message: "Ocorreu algum erro interno na aplicação",
                  success: false,
                  data: null
                );
        }

        public static ResultViewModel DomainError(string message)
        {
            return new ResultViewModel
                (
                  message: message,
                  success: false,
                  data: null
                );
        }

        public static ResultViewModel Error(string message)
        {
            return new ResultViewModel
                (
                  message: message,
                  success: false,
                  data: null
                );
        }
    }
}
