namespace TriviaQuizGame
{
    public class QuizProcessor
    {
        // load easy, medium or hard quiz
        public async Task LoadQuiz(string QuizDifficulty)
        {
            string url = $"https://opentdb.com/api.php?amount=10&category=18&difficulty={QuizDifficulty}&type=multiple";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {

            }


        }
    }
}
