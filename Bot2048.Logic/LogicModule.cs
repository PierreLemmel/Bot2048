using Ninject.Modules;

namespace Bot2048.Logic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDecisionMaker>().To<PriorityDecisionMaker>();
            Bind<IGameAnalyzer>().To<GameAnalyzer>();
            Bind<IGridUpdater>().To<GridUpdater>();
        }
    }
}
