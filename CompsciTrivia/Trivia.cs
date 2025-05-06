namespace CompsciTrivia
{
    public class Trivia
    {
        public List<QuizModel> QuestionsData { get; set; } = new List<QuizModel>();

        public double TimeConstraint { get; set; }
        public string Difficulty { get; set; }

        // for updating score etc
        public Player Player { get; set; }

        public Trivia(Player triviaPlayer)
        {
            Player = triviaPlayer;
            Difficulty = triviaPlayer.QuestionDifficulty;
            TimeConstraint = triviaPlayer.TimingDifficulty;
        }

        public async Task StartQuiz()
        {

            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(TimeConstraint));
            try
            {
                await StartQuestions(cts.Token);

            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"Times up!\n Your final score {Player.Score}/10");
            }

        }

        //int questionindex
        public async Task StartQuestions(CancellationToken token)
        {
            int questionNum = 1;
            Random random = new Random();
            foreach (var q in QuestionsData)
            {
                q.Incorrect_Answers.Add(q.Correct_Answer);
                var questionAnswers = q.Incorrect_Answers.OrderBy(x => random.Next()).ToList();

                Console.WriteLine($"\nQuestion {questionNum}: {q.Question}\n" +
                    $"Possible answers:\n");

                int answerNum = 0;
                foreach (var answer in questionAnswers)
                {
                    answerNum++;
                    Console.WriteLine($"{answerNum}. {answer}");
                }

                Console.WriteLine("Correct Answer: ");
                string userInput = Console.ReadLine().ToLower();
                if (int.TryParse(userInput, out int choice))
                {
                    // find correct answer index
                    if (questionAnswers[choice - 1] == q.Correct_Answer)
                    {
                        Player.Score++;
                    }
                }
                token.ThrowIfCancellationRequested();
                questionNum++;
            }
            Console.WriteLine($"Score: {Player.Score}/10");
        }


        public async Task SetUpQuestions()
        {
            ApiHelper.InitialiseClient();
            QuizProcessor processor = new QuizProcessor();
            var questions = await processor.LoadQuiz(Difficulty);

            foreach (var q in questions)
            {
                QuestionsData.Add(q);

            }
        }


        public void PrintAllQuestions()
        {
            int questionNum = 1;
            foreach (var q in QuestionsData)
            {
                foreach (var item in q.Incorrect_Answers)
                {

                    Console.WriteLine($"Q{questionNum}: {item}");
                }
                questionNum++;
            }
        }


    }
}
