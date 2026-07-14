# CSE 325 Week 03 — Blazor Pizza Application

This is a complete .NET 8 Blazor Web App prepared for the Week 03 assignment.

## Assignment requirements included

- A working Blazor web application.
- A visible **Get Pizza List** page.
- Razor components and C# data interaction.
- Pages, navigation, routing, and route parameters.
- A reusable layout with a header and footer.
- Every price is formatted as United Kingdom currency: **£ (GBP)**.
- Footer text: **© 2026 Olakunle Tayo Obademi | United Kingdom**.

## Requirements on your computer

1. .NET 8 SDK or a newer compatible SDK.
2. Visual Studio Code with the C# Dev Kit extension, or Visual Studio 2022.
3. Git, only if you want to upload the project to GitHub.

## Confirm that .NET is installed

Open a terminal and run:

```powershell
dotnet --version
```

A version beginning with `8`, `9`, or `10` should be suitable. If the command is not recognised, install the .NET SDK before continuing.

## Run the application

Open a terminal inside this project folder and run:

```powershell
dotnet restore
dotnet build
dotnet run
```

The terminal should display a local address similar to:

```text
http://localhost:5217
```

Open that address in your browser. Do not close the terminal while the application is running.

## What to check in the browser

Confirm all of the following:

1. The blue **Blazor Pizza** header is visible.
2. The heading **Get Pizza List** is visible.
3. Six pizzas are displayed.
4. Every price begins with the British pound symbol `£`.
5. The footer shows `© 2026 Olakunle Tayo Obademi | United Kingdom`.
6. Clicking **View details** opens a route such as `/pizza/1`.
7. Clicking **About** opens the About page.

## Stop the application

Return to the terminal and press:

```text
Ctrl + C
```

## Screenshot for Canvas

Make the browser wide enough to show the header, the pizza list, and the footer. If necessary, zoom out to 80% or 90%. Take one screenshot and save it as:

```text
Olakunle_Obademi_W03_Blazor_Application.png
```

Upload that image to Canvas.

## Upload to a new GitHub repository

Create an empty GitHub repository, then run these commands from this project folder:

```powershell
git init
git add .
git commit -m "Complete CSE 325 Week 03 Blazor application"
git branch -M main
git remote add origin YOUR_GITHUB_REPOSITORY_URL
git push -u origin main
```

Replace `YOUR_GITHUB_REPOSITORY_URL` with the URL GitHub gives you.
