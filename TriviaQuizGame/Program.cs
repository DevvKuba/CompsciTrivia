namespace TriviaQuizGame
{
    public class Program
    {
        static void Main(string[] args)
        {

            //var easyQuestions = "https://opentdb.com/api.php?amount=10&category=18&difficulty=easy&type=boolean";

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(easyQuestions);
            //Console.WriteLine(client.BaseAddress);

            ApiHelper.InitialiseClient();
        }
    }
}
