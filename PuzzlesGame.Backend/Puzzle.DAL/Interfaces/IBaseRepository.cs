namespace Puzzle.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
