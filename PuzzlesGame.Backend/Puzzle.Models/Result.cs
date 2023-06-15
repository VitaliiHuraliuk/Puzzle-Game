namespace Puzzle.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public int MovesCount { get; set; }
        public virtual User User { get; set; }
    }
}