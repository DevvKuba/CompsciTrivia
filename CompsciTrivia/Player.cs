namespace CompsciTrivia
{
    public class Player
    {
        public List<string> PossibleDifficulties { get; set; } = new List<string> { "easy", "medium", "hard" };
        public string QuestionDifficulty { get; set; }
        public double TimingDifficulty { get; set; }
        public string Name { get; set; }
        public int Score { get; set; } = 0;
        public Player(string name)
        {
            Name = name;
            SetQuestionDifficulty();
            SetTimerDifficulty();
        }

        public void SetQuestionDifficulty()
        {
            Console.WriteLine("What question difficulty would you like to play at?\n'easy', 'medium', or 'hard'");
            string questionDifficulty = Console.ReadLine().ToLower();
            if (PossibleDifficulties.Contains(questionDifficulty))
            {
                QuestionDifficulty = questionDifficulty;
                Console.WriteLine($"question difficulty set as: {questionDifficulty}");
            }
            else
            {
                throw new Exception("Incorrect question difficulty input");
            }

        }

        public void SetTimerDifficulty()
        {
            Console.WriteLine("What timer difficulty would you like to play at?\n'easy', 'medium', or 'hard'");
            string timerDifficulty = Console.ReadLine().ToLower();
            if (PossibleDifficulties.Contains(timerDifficulty))
            {
                TimingDifficulty = DetermineTriviaTimer(timerDifficulty);
                Console.WriteLine($"timer difficulty set as: {timerDifficulty} or {TimingDifficulty}s to complete all the questions");
            }
            else
            {
                throw new Exception("Incorrect question difficulty input");
            }

        }

        public int DetermineTriviaTimer(string difficulty)
        {
            if (difficulty == "easy")
            {
                return 180;
            }
            else if (difficulty == "medium")
            {
                return 150;
            }
            else if (difficulty == "hard")
            {
                return 90;
            }
            return 0;
        }
    }
}
