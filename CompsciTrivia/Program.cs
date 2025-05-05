namespace CompsciTrivia
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            ApiHelper.InitialiseClient();
            QuizProcessor processor = new QuizProcessor();
            var questions = await processor.LoadQuiz("medium");

            foreach (var q in questions)
            {
                Console.WriteLine(q.Question);
            }


        }
    }
}
