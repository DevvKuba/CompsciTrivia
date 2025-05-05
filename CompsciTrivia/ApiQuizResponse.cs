namespace CompsciTrivia
{
    public class ApiQuizResponse
    {
        public int ResponseCode { get; set; }
        public required List<QuizModel> Results { get; set; }


    }

}
