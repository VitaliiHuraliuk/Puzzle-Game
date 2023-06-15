namespace Puzzle.Models
{
    public class User
    {
     public string UserName;
     public int Id { get; set; }
     public string Login { get; set; }
     public string Password { get; set; }
     public ICollection<Result> Result { get; set; }

    }
}
