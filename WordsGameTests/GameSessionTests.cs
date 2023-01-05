using FluentAssertions;
using WordsGame;

namespace WordsGameTests;

public class GameSessionTests
{
    private static string[] words = new string[]
    {
        "аборт",
        "абзац",
        "камин",
        "лепта",
        "оброк",
        "песня",
        "юрист",
        "ягуар"
    };
    
    [Test]
    public void Try_returns_22222()
    {
        // Arrange
        var index = 0;
        var secret = words[index];
        var gameSession = new GameSession(words, index);
        var attempt = "аборт";
        var expected = "22222";

        // Act
        var actual = gameSession.Try(attempt);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void Try_returns_22000()
    {
        // Arrange
        var index = 0;
        var secret = words[index];
        var gameSession = new GameSession(words, index);
        var attempt = "абзац";
        var expected = "22000";

        // Act
        var actual = gameSession.Try(attempt);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void Try_returns_01002()
    {
        // Arrange
        var index = 0;
        var secret = words[index];
        var gameSession = new GameSession(words, index);
        var attempt = "юрист";
        var expected = "01002";

        // Act
        var actual = gameSession.Try(attempt);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void Try_returns_00011()
    {
        // Arrange

        var index = 0;
        var secret = words[index];
        var gameSession = new GameSession(words, index);
        var attempt = "ягуар";
        var expected = "00011";

        // Act
        var actual = gameSession.Try(attempt);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void Try_returns_00000()
    {
        // Arrange

        var index = 0;
        var secret = words[index];
        var gameSession = new GameSession(words, index);
        var attempt = "песня";
        var expected = "00000";

        // Act
        var actual = gameSession.Try(attempt);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void Try_returns_12100()
    {
        // Arrange

        var index = 0;
        var secret = words[index];
        var gameSession = new GameSession(words, index);
        var attempt = "оброк";
        var expected = "12100";

        // Act
        var actual = gameSession.Try(attempt);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void Try_returns_02110()
    {
        // Arrange

        var index = 4;
        var secret = words[index];
        var gameSession = new GameSession(words, index);
        var attempt = "аборт";
        var expected = "02110";

        // Act
        var actual = gameSession.Try(attempt);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void Try_returns_NotFound()
    {
        // Arrange

        var index = 4;
        var secret = words[index];
        var gameSession = new GameSession(words, index);
        var attempt = "ыыыыы";
        var expected = "Не знаем такого слова.";

        // Act
        var actual = gameSession.Try(attempt);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void Try_returns_WrongLengthShorter()
    {
        // Arrange

        var index = 4;
        var secret = words[index];
        var gameSession = new GameSession(words, index);
        var attempt = "лес";
        var expected = "Неправильная длина слова.";

        // Act
        var actual = gameSession.Try(attempt);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Test]
    public void Try_returns_WrongLenghtLonger()
    {
        // Arrange

        var index = 4;
        var secret = words[index];
        var gameSession = new GameSession(words, index);
        var attempt = "перила";
        var expected = "Неправильная длина слова.";

        // Act
        var actual = gameSession.Try(attempt);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}