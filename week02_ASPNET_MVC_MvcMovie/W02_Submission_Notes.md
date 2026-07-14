# W02 ASP.NET Core MVC Assignment Notes

## Goal

Build the Week 2 ASP.NET Core MVC movie application and complete the extra rubric requirements.

## Setup Steps

1. Created the MVC project inside the Week 2 folder:

   ```bash
   cd week02
   dotnet new mvc -o MvcMovie
   ```

2. Confirmed the workspace is using the .NET 8 SDK from `global.json`:

   ```bash
   dotnet --version
   ```

3. Added Entity Framework Core with SQLite so the app can store movie records:

   ```bash
   cd week02/MvcMovie
   dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.22
   ```

4. Added a `Movie` model with title, release date, genre, price, and rating fields.

5. Added `MvcMovieContext` so Entity Framework can connect the app to a SQLite database.

6. Registered the database context in `Program.cs`.

7. Added `SeedData` so the app automatically creates sample movie records the first time it runs.

8. Added `MoviesController` with actions for:

   - Listing movies
   - Searching by title
   - Filtering by genre
   - Searching by release year or newer
   - Viewing details
   - Creating movies
   - Editing movies
   - Deleting movies

9. Added Razor views for the movie pages:

   - `Index`
   - `Create`
   - `Edit`
   - `Details`
   - `Delete`

10. Changed the app title from `MvcMovie` to `Olakunle Obademi Movies`.

11. Changed the movie listing heading from `Index` to `My Favorite Movies`.

12. Added input padding in `wwwroot/css/site.css`.

## Rubric Checklist

- Build ASP.NET application: complete
- Title changed to include name: complete, `Olakunle Obademi Movies`
- At least three movie records added: complete, four seeded movies
- Listing page heading changed from `Index`: complete, `My Favorite Movies`
- Search by year added: complete, `Released Year Or Newer`
- Form input padding added: complete

## Verification

The project builds successfully:

```bash
dotnet build
```

The Movies page was tested locally at:

```text
http://localhost:5008/Movies
```
