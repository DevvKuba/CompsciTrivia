namespace CompsciTrivia
{
    public class Trivia
    {
        public List<QuizModel> Questions { get; set; } = new List<QuizModel>();

        public DateTime TimeConstraint { get; set; }
        public string Difficulty { get; set; }
        public Trivia(Player triviaPlayer)
        {
            DateTime date = new DateTime();
            Difficulty = triviaPlayer.QuestionDifficulty;
            TimeConstraint = date.AddSeconds(triviaPlayer.TimingDifficulty);
        }

        public async Task SetUpQuestions()
        {
            ApiHelper.InitialiseClient();
            QuizProcessor processor = new QuizProcessor();
            var questions = await processor.LoadQuiz(Difficulty);

            foreach (var q in questions)
            {
                Questions.Add(q);
            }
            // to test
            Console.WriteLine(Questions[0].Question);
        }


    }
}
