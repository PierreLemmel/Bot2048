using System.Collections.Generic;
using System.Threading.Tasks;
using Bot2048.Model;

namespace Bot2048.Automating
{
    public interface IAutomatingControler
    {
        bool DetectGameOver();
        int ReadScore();
        IEnumerable<GridUpdateInput> ReadGridState();
        Task NextStep(Direction direction);
        Task OpenWebPage();
        Task Replay();
    }
}