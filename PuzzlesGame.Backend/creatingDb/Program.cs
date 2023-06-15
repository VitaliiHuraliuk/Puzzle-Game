using Puzzle.DAL;

var puzzleDb = new PuzzleDbContext();
puzzleDb.Database.EnsureDeleted();
puzzleDb.Database.EnsureCreated();
Console.ReadKey();
