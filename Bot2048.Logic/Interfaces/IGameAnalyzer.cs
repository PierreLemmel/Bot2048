using Bot2048.Model;

namespace Bot2048.Logic
{
    public interface IGameAnalyzer
    {
        bool CanMoveLeft(Grid grid);
        bool CanMoveRight(Grid grid);
        bool CanMoveDown(Grid grid);
        bool CanMoveUp(Grid grid);
    }
}