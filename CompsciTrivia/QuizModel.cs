namespace CompsciTrivia
{
    public class QuizModel
    {
        public required string Question { get; set; }
        public required string Correct_Answer { get; set; }

        public required List<string> Incorrect_Answers { get; set; }
    }
}
