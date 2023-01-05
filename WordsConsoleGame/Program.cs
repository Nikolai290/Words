using System.ComponentModel.Design;
using WordsGame;

namespace WordsConsoleGame;

public class Program
{
    public static void Main()
    {
        var path = "C:/REPOS/Trainee/Words/russian_nouns.txt";
        string input;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Угадай слово из 5 букв. Чтобы начать введите play.");

            input = Console.ReadLine().ToLower();

            if (input.Equals("exit"))
            {
                break;
            }

            if (input.Equals("play"))
            {
                Play(path);
            }

            ShowHelp();
        }
    }

    private static void ShowHelp()
    {
        Console.WriteLine("Игра угадай слово из 5 букв.");
        Console.WriteLine("Для старта игры введите play.");
        Console.WriteLine("Для выхода из игры или из игровой сессии введите exit.");
        Console.WriteLine("Во время игры ведите существительное слово из 5 букв и нажмите Enter.");
        Console.WriteLine("Если в загаданном слове есть буква из введённого вами, то она подстветится жёлтым.");
        Console.WriteLine("Если в загаданном слове буква из введённого вами стоит на том же месте, то она подстветится зелёным.");
        Console.WriteLine("Если буквы серые - их нет в загаднном слове.");
        Console.WriteLine("У вас есть 5 попыток, чтобы угадать загаданное слово.");
        Console.WriteLine("Если попытки закончились или вы выиграли, то введите exit чтобы закончить игровую сессию.");
        Console.WriteLine("После этого вы можете начать новую сессию введя play или выйти из игры снова введя exit.");
        Console.ReadKey();
    }

    private static void Play(string path)
    {
        string input;
        string result;

        var gameSession = WordsGameManager.StartNewGameSession(path);

        while (true)
        {
            Console.Write($"Try {gameSession.GetAttemtps}: ");
            input = Console.ReadLine().ToLower().Trim();
            if (input.Equals("exit"))
            {
                break;
            }

            result = gameSession.Try(input);

            if (result.Length != 5)
            {
                Console.WriteLine(result);
                continue;
            }

            for (int i = 0; i < input.Length; i++)
            {
                var defaultColor = Console.ForegroundColor;
                if (result[i] == '0')
                {
                }
                else if (result[i] == '1')
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else if (result[i] == '2')
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(input[i]);
                Console.ForegroundColor = defaultColor;
            }
            Console.WriteLine();
        }
    }
}