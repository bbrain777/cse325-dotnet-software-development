namespace ConnectFour.Game;

public sealed class GameState
{
    public const int Rows = 6;
    public const int Columns = 7;

    private readonly int[,] board = new int[Rows, Columns];

    public enum WinState
    {
        NoWinner,
        Player1Wins,
        Player2Wins,
        Tie
    }

    public sealed record Move(int Number, int Player, int Column, int Row);

    public int PlayerTurn { get; private set; } = 1;
    public int CurrentTurn => Moves.Count;
    public WinState Result { get; private set; } = WinState.NoWinner;
    public List<Move> Moves { get; } = [];
    public int Player1Wins { get; private set; }
    public int Player2Wins { get; private set; }
    public int Ties { get; private set; }

    public int GetCell(int row, int column) => board[row, column];

    public bool IsColumnFull(int column) => board[0, column] != 0;

    public Move PlayPiece(int column)
    {
        if (column is < 0 or >= Columns)
        {
            throw new ArgumentOutOfRangeException(nameof(column), "Choose a column from 1 to 7.");
        }

        if (Result != WinState.NoWinner)
        {
            throw new InvalidOperationException("The game is over. Start a new round to continue.");
        }

        if (IsColumnFull(column))
        {
            throw new InvalidOperationException($"Column {column + 1} is full. Choose another column.");
        }

        var row = Rows - 1;
        while (board[row, column] != 0)
        {
            row--;
        }

        var player = PlayerTurn;
        board[row, column] = player;
        var move = new Move(Moves.Count + 1, player, column, row);
        Moves.Add(move);

        Result = CalculateResult(row, column, player);
        if (Result == WinState.Player1Wins)
        {
            Player1Wins++;
        }
        else if (Result == WinState.Player2Wins)
        {
            Player2Wins++;
        }
        else if (Result == WinState.Tie)
        {
            Ties++;
        }
        else
        {
            PlayerTurn = player == 1 ? 2 : 1;
        }

        return move;
    }

    public void ResetBoard(bool resetScore = false)
    {
        Array.Clear(board);
        Moves.Clear();
        Result = WinState.NoWinner;
        PlayerTurn = 1;

        if (resetScore)
        {
            Player1Wins = 0;
            Player2Wins = 0;
            Ties = 0;
        }
    }

    private WinState CalculateResult(int row, int column, int player)
    {
        int[][] directions = [[0, 1], [1, 0], [1, 1], [1, -1]];

        foreach (var direction in directions)
        {
            var connected = 1
                + CountDirection(row, column, direction[0], direction[1], player)
                + CountDirection(row, column, -direction[0], -direction[1], player);

            if (connected >= 4)
            {
                return player == 1 ? WinState.Player1Wins : WinState.Player2Wins;
            }
        }

        return Moves.Count == Rows * Columns ? WinState.Tie : WinState.NoWinner;
    }

    private int CountDirection(int row, int column, int rowStep, int columnStep, int player)
    {
        var count = 0;
        row += rowStep;
        column += columnStep;

        while (row is >= 0 and < Rows && column is >= 0 and < Columns && board[row, column] == player)
        {
            count++;
            row += rowStep;
            column += columnStep;
        }

        return count;
    }
}
