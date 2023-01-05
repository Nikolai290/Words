namespace WordsGame;

public static class WordsGameManager
{
    private static readonly Random _random = new Random();

    public static GameSession StartNewGameSession(string russianNounsPath)
    {
        GameSession gameSession;
        using (var stream = new StreamReader(russianNounsPath))
        {
            var words = stream.ReadToEndAsync().Result.Replace("\r", "").Split('\n');

            gameSession = new GameSession(words, _random.Next(words.Length));
        }

        return gameSession;
    }
}