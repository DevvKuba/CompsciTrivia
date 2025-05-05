using System.Net.Http.Json;

namespace CompsciTrivia
{
    public class QuizProcessor
    {

        // load easy, medium or hard quiz
        public async Task<List<QuizModel>> LoadQuiz(string QuizDifficulty)
        {
            string url = $"https://opentdb.com/api.php?amount=10&category=18&difficulty={QuizDifficulty}&type=multiple";

            // deserlialise the JSON response into ApiQuizResponse format - look at properties
            var response = await ApiHelper.ApiClient.GetFromJsonAsync<ApiQuizResponse>(url);

            // Transform API questions into simplified QuizModel - look at properties
            return response.Results.Select(q => new QuizModel
            {
                Question = q.Question,
                Correct_Answer = q.Correct_Answer,
                Incorrect_Answers = q.Incorrect_Answers
            }).ToList();


        }
    }
}
