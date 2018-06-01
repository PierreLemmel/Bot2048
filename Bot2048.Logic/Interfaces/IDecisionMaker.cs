using Bot2048.Model;

namespace Bot2048.Logic
{
    public interface IDecisionMaker
    {
        Direction ChoseDirection(Grid grid);
    }
}
