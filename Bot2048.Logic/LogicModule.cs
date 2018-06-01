using Ninject.Modules;

namespace Bot2048.Logic
{
    public class LogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameAnalyzer>().To<GameAnalyzer>();

            Bind<IDecisionMaker>().To<RandomDecisionMaker>();
        }
    }
}
