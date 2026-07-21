# Connect Four — CSE 325 Week 04

A .NET 8 Blazor Web App based on the Microsoft Learn **Build a Connect Four game with Blazor** module.

## Run the app

```powershell
dotnet run --project ConnectFour
```

Open the HTTP or HTTPS address printed in the terminal.

## Run the tests

```powershell
dotnet test ConnectFour.sln
```

## Included functionality

- Seven-column, six-row Connect Four board
- Alternating turns and gravity-based piece placement
- Horizontal, vertical, and diagonal win detection
- Tie, game-over, and full-column handling
- New-round and full-score reset controls
- Component color parameters and live player color selectors
- Responsive and keyboard-accessible interface
- Additional feature: persistent match scoreboard and move-by-move history

## Suggested video demonstration

1. Show alternating turns and pieces falling to the lowest open row.
2. Complete a four-piece line and show the win message.
3. Select **Play again** and show that the match score remains.
4. Point out the move-history list and live player color controls.
5. Show **Reset match score**.
