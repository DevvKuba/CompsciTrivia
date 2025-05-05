namespace CompsciTrivia
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Player player1 = new Player("Goomba");
            Trivia csTrivia = new Trivia(player1);
            await csTrivia.SetUpQuestions();

            Console.WriteLine(csTrivia.Difficulty);



        }
    }
}
