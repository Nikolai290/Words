namespace WordsGame;

public class GameSession
{
    public int GetAttemtps { get; private set; }
    private string[] _words;
    private string _secret;

    public GameSession(string[] words, int index)
    {
        _words = words;
        var secret = words[index];

        _secret = secret;
        GetAttemtps = 5;
    }


    public string Try(string guess)
    {
        var result = "";

        if (GetAttemtps <= 0)
        {
            result = $"Попытки закончились.\nБыло загадано слово {_secret}";
            return result;
        }
        
        if (guess.Length != 5)
        {
            result = "Неправильная длина слова.";
            return result;
        }

        if (!_words.Contains(guess))
        {
            result = "Не знаем такого слова.";
            return result;
        }
        
        if (guess.Equals(_secret))
        {
            result = "22222";
            return result;
        }
        
        var exactly = "";
        var about = "";

        for (int i = 0; i < _secret.Length; i++)
        {
            var secretChar = _secret[i];
            var guessChar = guess[i];
            var entries = about.Count(c => c == guessChar) + exactly.Count(c => c == guessChar);


            if (guessChar == secretChar)
            {
                exactly += guessChar;
                result += "2";
            }
            else if (_secret.Contains(guessChar) &&
                     !exactly.Contains(guessChar) &&
                     entries < _secret.Count(c => c == guessChar))
            {
                about += guessChar;
                result += "1";
            }
            else
            {
                result += "0";
            }
        }

        GetAttemtps--;

        return result;
    }
}