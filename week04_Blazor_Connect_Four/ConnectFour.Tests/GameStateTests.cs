using ConnectFour.Game;

namespace ConnectFour.Tests;

public sealed class GameStateTests
{
    [Fact]
    public void PlayPiece_DropsToLowestOpenRow_AndAlternatesPlayers()
    {
        var game = new GameState();

        var first = game.PlayPiece(3);
        var second = game.PlayPiece(3);

        Assert.Equal((5, 3, 1), (first.Row, first.Column, first.Player));
        Assert.Equal((4, 3, 2), (second.Row, second.Column, second.Player));
        Assert.Equal(1, game.PlayerTurn);
    }

    [Fact]
    public void PlayPiece_DetectsHorizontalWin()
    {
        var game = Play(0, 0, 1, 1, 2, 2, 3);

        Assert.Equal(GameState.WinState.Player1Wins, game.Result);
        Assert.Equal(1, game.Player1Wins);
    }

    [Fact]
    public void PlayPiece_DetectsVerticalWin()
    {
        var game = Play(0, 1, 0, 1, 0, 1, 0);

        Assert.Equal(GameState.WinState.Player1Wins, game.Result);
    }

    [Fact]
    public void PlayPiece_DetectsDiagonalWin()
    {
        var game = Play(0, 1, 1, 2, 4, 2, 2, 3, 4, 3, 5, 3, 3);

        Assert.Equal(GameState.WinState.Player1Wins, game.Result);
    }

    [Fact]
    public void PlayPiece_RejectsAFullColumn()
    {
        var game = Play(0, 0, 0, 0, 0, 0);

        var error = Assert.Throws<InvalidOperationException>(() => game.PlayPiece(0));

        Assert.Contains("full", error.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void ResetBoard_ClearsPiecesButCanKeepOrResetScore()
    {
        var game = Play(0, 0, 1, 1, 2, 2, 3);

        game.ResetBoard();
        Assert.Equal(1, game.Player1Wins);
        Assert.Empty(game.Moves);

        game.ResetBoard(resetScore: true);
        Assert.Equal(0, game.Player1Wins);
    }

    private static GameState Play(params int[] columns)
    {
        var game = new GameState();
        foreach (var column in columns)
        {
            game.PlayPiece(column);
        }

        return game;
    }
}
